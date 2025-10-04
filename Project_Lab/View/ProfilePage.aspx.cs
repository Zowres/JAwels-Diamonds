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
    public partial class ProfilePage : System.Web.UI.Page
    {
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                checkUser();
            }
        }

        private void checkUser()
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
            else
            {
                usernamelbL.Text = user.UserName;
                emailLbl.Text = user.UserEmail;
                genderLbl.Text = user.UserGender;
                roleLbl.Text = user.UserRole;
            }

        }

        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;


            String oldPassword = oldPasswordTB.Text;
            String newPassword = newPasswordTB.Text;
            String confirmPassword = confirmPasswordTB.Text;


            String errorMsg = uc.validatePassword(oldPassword, user.UserId);
            if (errorMsg == null)
            {
                errorMsg = uc.changePassword(newPassword, confirmPassword, user.UserId);
            }

            LblerrorMsg.Text = errorMsg;

        }
    }
}