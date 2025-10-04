using Project_Lab.Controller;
using Project_Lab.Dataset;
using Project_Lab.Model;
using Project_Lab.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View.AdminPage
{
    public partial class ReportPage : System.Web.UI.Page
    {
        UserController uc = new UserController();
        AdminController ac = new AdminController();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                checkAdmin();
                makeReport();
            }
        }

        private void makeReport()
        {
            TransactionReport report = new TransactionReport();

            CrystalReportViewer1.ReportSource = report;
            DataSet1 data = getData(ac.getAllTransactionReport());
            report.SetDataSource(data);
        }

        private DataSet1 getData(List<TransactionHeader> transaction)
        {
            DataSet1 data = new DataSet1();

            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach(TransactionHeader t in transaction)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionId"] = t.TransactionId;
                hrow["UserId"] = t.UserId;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["PaymentMethod"] = t.PaymentMethod;
                hrow["TransactionStatus"] = t.TransactionStatus;

                int total = 0;

                foreach(TransactionDetail td in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionId"] = td.TransactionId;
                    drow["JewelId"] = td.JewelId;
                    drow["Quantity"] = td.Quantity;
                    drow["Subtotal"] = td.MsJewel.JewelPrice * td.Quantity;
                    detailTable.Rows.Add(drow);
                    total+= td.MsJewel.JewelPrice * td.Quantity;
                }
                hrow["GrandTotal"] = total;
                headerTable.Rows.Add(hrow);
            }

            return data;
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
    }
}