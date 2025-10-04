using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Factory
{
    public class UserFactory
    {
        public MsUser createUser(string email, string username, string password, string cpass, string gender, DateTime dob)
        {
            MsUser user = new MsUser();

            user.UserEmail = email;
            user.UserName = username;
            user.UserGender = gender;
            user.UserPassword = password;
            user.UserDOB = dob;
            user.UserRole = "Customer";
            
            return user;
        }

        
        
    }

}