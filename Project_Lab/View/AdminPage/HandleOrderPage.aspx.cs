using Project_Lab.Controller;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace Project_Lab.View.AdminPage
{
    public partial class HandleOrderPage : System.Web.UI.Page
    {
        OrderController oc = new OrderController();
        AdminController ac = new AdminController();
        UserController uc = new UserController();   
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                checkAdmin();
                bindingData();
            }
        }

        protected void bindingData()
        {
            List<TransactionHeader> listTransaction = ac.getAllTransactionForAdmin();

            HandleOrderGV.DataSource = listTransaction;
            HandleOrderGV.DataBind();

        }

        private void checkAdmin()
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


            if (user == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            else if (!uc.validateUserAdmin(user.UserId))
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

        }


        protected void HandleOrderGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();

                Button btnShip = (Button)e.Row.FindControl("btnShip");
                Button btnConfirm = (Button)e.Row.FindControl("btnConfirm");
                Label lblText = (Label)e.Row.FindControl("confirmUserLbl");

                if(status.Equals("Arrived", StringComparison.OrdinalIgnoreCase))
                {
                    lblText.Visible = true;
                    btnShip.Visible = false;
                    btnConfirm.Visible = false;
                }
                
                if(status.Equals("Shipment Pending", StringComparison.OrdinalIgnoreCase))
                {
                    lblText.Visible = false;
                    btnShip.Visible = true;
                    btnConfirm.Visible = false;
                }

                if (status.Equals("Payment Pending", StringComparison.OrdinalIgnoreCase))
                {
                    lblText.Visible = false;
                    btnShip.Visible = false;
                    btnConfirm.Visible = true;
                }


            }
        }

        protected void HandleOrderGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.ToString() == "ShipPackage")
            {
                //ubah status transaksi ke Arrived
                if (int.TryParse(e.CommandArgument.ToString(), out int transactionId))
                {
                    ac.updateStatusTransactionArrived(transactionId);
                    bindingData();
                }
            }
            if (e.CommandName.ToString() == "Confirm")
            {
                //ubah status jadi Shipment Pending
                if (int.TryParse(e.CommandArgument.ToString(), out int transactionId))
                {
                    ac.updateStatusTransactionShipmentPending(transactionId);
                    bindingData();
                }
            }

            Response.Redirect(Request.RawUrl);
        }
    }
}