using Project_Lab.Controller;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View.CustomerPage
{
    public partial class CartPage : System.Web.UI.Page
    {
        UserController uc = new UserController();
        CartController cc = new CartController();   
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                checkCustomer();
                BindGridView();
                Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode;
            }
        }

        private void BindGridView()
        {
            MsUser user = Session["user"] as MsUser;


            List<CartViewModel> listCart = cc.getListCartView(user.UserId);

            if (listCart != null)
            {

                CartGridView.DataSource = listCart;
                CartGridView.DataBind();


                lblTotal.Text = Convert.ToString(cc.totalPrice(user.UserId));
            }
        }

        private void checkCustomer()
        {
            MsUser user = Session["user"] as MsUser;


            if (user == null)
            {
                HttpCookie userCookie = Request.Cookies["user_cookie"];

                if (userCookie != null)
                {
                    string id = userCookie.Value;

                    if (string.IsNullOrEmpty(id))
                    {
                        user = null;
                        Session["user"] = user;
                        userCookie = null;
                    }
                    else
                    {
                        user = uc.getCookie(id);
                        Session["user"] = user;
                    }

                }
            }

            if(user == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            else if (!uc.validateUserCustomer(user.UserId))
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

        }

       


        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            GridViewRow row = CartGridView.Rows[e.RowIndex];
            int jewelId = int.Parse(row.Cells[0].Text);
         
           
            cc.deleteItem(jewelId,user.UserId);
            BindGridView();
            Response.Redirect("~/View/CustomerPage/CartPage.aspx");
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            lblMessage.Text = "";
            MsUser user = Session["user"] as MsUser;
            GridViewRow row = CartGridView.Rows[e.NewEditIndex];
            int jewelId = int.Parse(row.Cells[0].Text);
            TextBox txtQty = (TextBox)row.FindControl("txtQuantity");
            int newQuantity;

            if (int.TryParse(txtQty.Text, out newQuantity))
            {
                //update item di database nya pake quantity yang baru di cart
                cc.updateQuantity(newQuantity, jewelId, user.UserId);
                CartGridView.EditIndex = -1;
                BindGridView();
                Response.Redirect("~/View/CustomerPage/CartPage.aspx");
            }
            else
            {
                lblMessage.Text = "Quantity must be numeric";
            }
        }

        protected void CartGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CartGridView.EditIndex = -1;
            BindGridView();
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            cc.deleteAllCarts(user.UserId);
            BindGridView();
            Response.Redirect("~/View/CustomerPage/CartPage.aspx");
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            String paymentMethod = ddlPaymentMethod.Text;

            if (!String.IsNullOrEmpty(paymentMethod))
            {
                cc.addTransaction(user.UserId, paymentMethod);
                cc.deleteAllCarts(user.UserId);
                BindGridView();
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Please choose the payment method!";
            }
        }

    }   
}