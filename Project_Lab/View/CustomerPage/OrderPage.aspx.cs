using Project_Lab.Controller;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;
using static System.Collections.Specialized.BitVector32;

namespace Project_Lab.View.CustomerPage
{
    public partial class OrderPage : System.Web.UI.Page
    {
        OrderController oc = new OrderController();
        UserController uc = new UserController(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkCustomer();
                bindingData();
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

            if (user == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            else if (!uc.validateUserCustomer(user.UserId))
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void bindingData()
        {
            MsUser user = Session["user"] as MsUser;
            List<TransactionHeader> listTransaction = oc.getAllTransactionByUserId(user.UserId);

            OrderGV.DataSource = listTransaction;
            OrderGV.DataBind();

        }



        protected void OrderGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();

                Button btnView = (Button)e.Row.FindControl("btnView");
                Button btnConfirm = (Button)e.Row.FindControl("btnConfirm");
                Button btnReject = (Button)e.Row.FindControl("btnReject");

                // Semua status bisa View
                btnView.Visible = true;

                // Confirm dan Reject hanya muncul jika status "Arrived"
                bool isArrived = status.Equals("Arrived", StringComparison.OrdinalIgnoreCase);
                btnConfirm.Visible = isArrived;
                btnReject.Visible = isArrived;
            }
        }



        protected void OrderGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "ViewDetails")
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int transactionId))
                {
                    Response.Redirect("~/View/CustomerPage/TransactionDetailPage.aspx?transactionId=" + transactionId);
                }
            }

            if (e.CommandName.ToString() == "Confirm")
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int transactionId))
                {
                    oc.updateStatusTransactionConfirm(transactionId);
                    bindingData();
                }
            }

            if (e.CommandName.ToString() == "Reject")
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int transactionId))
                {
                    oc.updateStatusTransactionReject(transactionId);
                    bindingData();
                }
            }

        }

    

        
    }
}