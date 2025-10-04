using Project_Lab.Handler;
using Project_Lab.Model;
using Project_Lab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;

namespace Project_Lab.Controller
{
    public class UserController
    {
        UserHandler userHandler = new UserHandler();
        
        public String validateRegister(string email, string username, string password, string cpass , string gender, DateTime dob)
        {
            string message = "Success to Register";
            if (string.IsNullOrEmpty(email))
            {
                message = "Email must be filled.";
            }
            else if (!email.EndsWith("@gmail.com"))
            {
                message = "Email must ends with @gmail.com";
            }
            else if (userHandler.emailCheck(email))
            {
                message = "Email has been used";
            }
            else if(username.Length < 3 || username.Length > 25)
            {
                message = "Username length must between 3 and 25.";
            }
            else if (!IsAlphanumeric(password))
            {
                message = "Password must be Alphanumeric!";
            }
            else if(password.Length < 8 || password.Length > 20 )
            {
                message = "Password length must between 8 and 20";
            }
            else if(cpass != password)
            {
                message = "Password must be same";
            }
            else if (string.IsNullOrEmpty(gender)){
                message = "Gender cannot be empty";
            }
            else if (!gender.Equals("Male") && !gender.Equals("Female"))
            {
                message = "Gender must be Male or Female";
            }
            else if(dob == DateTime.MinValue)
            {
                message = "Date time cannot be empty";
            }
            else if (!userHandler.dateCheck(dob))
            {
                message = "Date must be earlier than 01/01/2010";
            }
            else
            {
                userHandler.insertUserRegister(email, username, password, cpass, gender, dob);
                message = null;
            }

            return message;
        }
        
        public MsUser validateLogin(string email, string password)
        {
            
            MsUser user = userHandler.getUserLogin(email, password);
            if (email == "")
            {
                return null;
            }
            else if(password == "")
            {
                return null;
            }
            else if (user == null)
            {
                return null; 
            }
            else
            {
                return user;
            }
            
        }

        public MsUser getCookie(string key)
        {
            MsUser user = userHandler.getUserFromCookie(key);
            return user;
        }

        public String validatePassword(String password, int id)
        {
            String errorMsg = null;

            if(!userHandler.validatePassword(password, id))
            {
                errorMsg = "Password is wrong";
            }


            return errorMsg;
        }

        public String changePassword(String password, String confirmPass,int id)
        {
            String errorMsg = null;
            if (confirmPass != password)
            {
                errorMsg = "The New Password must be same!";
            }
            else if (password.Length < 8 || password.Length > 25)
            {
                errorMsg = "Password length must between 8 and 25";
            }
            else if (!IsAlphanumeric(password))
            {
                errorMsg = "Password must be alphanumeric!";
            }
            else
            {
                userHandler.changePasswordAccount(password, id);
                errorMsg = "Password successfully changed";
            }
            return errorMsg;
        }

        public static bool IsAlphanumeric(string inputString)
        {
            bool isAlpha = false;
            bool isDigit = false;
            if (inputString == null)
            {
                return false;
            }
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    isDigit = true;
                }
                else if(char.IsLetter(c))
                {
                    isAlpha = true;
                }
            }

            return isAlpha && isDigit;
        }
        public bool validateUserAdmin(int userId)
        {
            return userHandler.validateUserAdmin(userId);
        }

        public bool validateUserCustomer(int userId)
        {
            return userHandler.validateUserCustomer(userId);
        }

    }
}