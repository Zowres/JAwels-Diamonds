using Project_Lab.Controller;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View.MasterPage { 
    public partial class NavbarCustomer : System.Web.UI.MasterPage
    {
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack) {
                MsUser user = Session["user"] as MsUser;


                if(user == null)
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
                    Guest.Visible = true;
                    Customer.Visible = false;
                    Admin.Visible = false;

                    TypewriterText.Text = "Welcome To JAwels & Diamonds ";
                }
                else if (user.UserRole.Equals("Admin"))
                {
                    Guest.Visible = false;
                    Customer.Visible = false;
                    Admin.Visible = true;

                    TypewriterText.Text = "Hello, " + user.UserName + "!";
                }
                else {
                    Guest.Visible = false;
                    Customer.Visible = true;
                    Admin.Visible = false;

                    TypewriterText.Text = "Hello, " + user.UserName + "!";
                }
            
            }

        }

        protected void LogOut_Click(object sender, EventArgs e)
        { 
            MsUser user = Session["user"] as MsUser;

            if (user != null)
            {
                Session.Clear();
                Session.Abandon();
                foreach (string cookieKey in Request.Cookies.AllKeys)
                {
                    HttpCookie cookie = new HttpCookie(cookieKey);
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/View/HomePage.aspx");

            }
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/View/HomePage.aspx");
            TypewriterText.Text = "";
        }
    }
}