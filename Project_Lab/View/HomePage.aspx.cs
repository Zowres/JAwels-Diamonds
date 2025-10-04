using Project_Lab.Controller;
using Project_Lab.Model;
using Project_Lab.View.MasterPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View
{
    public partial class HomePage : System.Web.UI.Page
    {  
        UserController uc = new UserController();
        JewelController jc = new JewelController(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Response.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/View/LoginPage.aspx");
            }

            if (!IsPostBack)
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

                // Ngebind data jewelnya
                List<MsJewel> jewelList = jc.getAllJewel();

                if (jewelList != null)
                {
                    JewelGridView.DataSource = jewelList;
                    JewelGridView.DataBind();
                }

            }
        }

        protected void JewelGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                string jewelId = e.CommandArgument.ToString();
                Response.Redirect("DetailPage.aspx?id=" + jewelId);
            }
        }
    }
}
    