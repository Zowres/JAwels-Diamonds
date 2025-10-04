using Project_Lab.Controller;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        UserController userControl = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Response.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string email = EmailTB.Text;
            string password = PasswordTB.Text;

            MsUser users = userControl.validateLogin(email, password);

            if(users != null)
            {
                ErrorMessage.Text = "";
                Session["user"] = users;

                if(RememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = users.UserId.ToString();
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("~/View/HomePage.aspx");
            }
            else
            {
                ErrorMessage.Text = "Invalid Credentials.";

            }

        }
    }
}