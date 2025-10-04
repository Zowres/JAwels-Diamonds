using Project_Lab.Factory;
using Project_Lab.Model;
using Project_Lab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Project_Lab.Handler
{

    public class UserHandler
    {
        UserRepository userRepo = new UserRepository();
        public void insertUserRegister(string email, string username, string password, string cpass, string gender, DateTime dob)
        {
       
            userRepo.insertUser(email, username, password, cpass, gender, dob);
        }

        public bool dateCheck(DateTime dob)
        {
            DateTime maxDate = new DateTime(2010, 1, 1);
            if (dob > maxDate)
            {
                return false;
            }
            return true;
        }

        public bool emailCheck(string email) {

            MsUser user = userRepo.getEmail(email);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public MsUser getUserFromCookie(string key)
        {
            if(key == null)
            {
                return null;
            }

            int id = Convert.ToInt32(key);

            MsUser user = userRepo.getUserFromId(id);
            return user;
        }

        public MsUser getUserLogin(string email, string password)
        {
            MsUser users = userRepo.getUserLog(email, password);
            return users;
        }

        public Boolean validatePassword(String password, int userId)
        {
            MsUser user = userRepo.validatePassword(password, userId);

            if(user == null)
            {
                return false;
            }

            return true;

        }

        public bool validateUserAdmin(int userId)
        {
            return userRepo.getUserRole(userId) == "Admin";
        }

        public bool validateUserCustomer(int userId)
        {
            return userRepo.getUserRole(userId) == "Customer";
        }

        public void changePasswordAccount(String password, int userId)
        {
            userRepo.changePasswordAccount(password, userId);
        }
    }
}