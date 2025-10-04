using Project_Lab.Controller;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View.CustomerPage
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        UserController uc = new UserController();
        OrderController oc = new OrderController();
        
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

        private void bindingData()
        {
            int transactionId = Convert.ToInt32(Request.QueryString["transactionId"]);
            List<TransactionDetailView> listTransaction = oc.getAllTransactionDetail(transactionId);

            TransactionGV.DataSource = listTransaction; 
            TransactionGV.DataBind();
        }

    }
}