using Project_Lab.Factory;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Project_Lab.Repository
{
    public class UserRepository
    {
        DatabaseEntities db = new DatabaseEntities();
        UserFactory uf = new UserFactory();    
        public MsUser getUserLog(string email,string password)
        {
            MsUser user = (from usr in db.MsUsers
                           where usr.UserEmail == email
                           && usr.UserPassword == password
                           select usr).FirstOrDefault();

            return user;
        }

        public MsUser getEmail(string email)
        {
            MsUser user = (from usr in db.MsUsers
                           where email == usr.UserEmail
                           select usr).FirstOrDefault();
            return user;
        }

        public void insertUser(string email, string username, string password, string cpass, string gender, DateTime dob)
        {
            MsUser user = uf.createUser(email, username, password, cpass, gender, dob);
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public MsUser getUserFromId(int id)
        {
            MsUser user = (from usr in db.MsUsers
                           where id == usr.UserId
                           select usr).FirstOrDefault();

            return user;
        }

        public MsUser validatePassword(String password, int userId)
        {
            MsUser user = (from usr in db.MsUsers where usr.UserId == userId
                             && password == usr.UserPassword select usr).ToList().FirstOrDefault();

            return user;
        }

        public void changePasswordAccount(String password, int userId)
        {
            MsUser user = (from usr in db.MsUsers
                           where usr.UserId == userId select usr).ToList().FirstOrDefault();

            user.UserPassword = password;
            db.MsUsers.AddOrUpdate(user);
            db.SaveChanges();
            
        }
        
        public String getUserRole(int userId)
        {
            String user = (from usr in db.MsUsers
                           where usr.UserId == userId select usr.UserRole).FirstOrDefault();

            return user;
        }

    }
}