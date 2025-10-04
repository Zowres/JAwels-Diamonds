using Project_Lab.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        UserController userControl = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string email = emailTB.Text;
            string username = UsernameTB.Text;
            string password = PasswordTB.Text;
            string confirmPass = CPasswordTB.Text;
            string gender = GenderRBL.SelectedValue;
            DateTime dob = DobCalender.SelectedDate;

            String message = userControl.validateRegister(email,username,password, confirmPass, gender,dob); 
            
            if(message == null)
            {
                Response.Redirect("~/View/LoginPage.aspx");
            }
            
            ErrorMessage.Text = message;

        }
    }
}