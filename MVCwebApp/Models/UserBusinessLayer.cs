using MVCwebApp.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwebApp.Models
{
    public class UserBusinessLayer
    {
        public List<UserDetails> GetUsers()
        {
            SalesERPDAL userDAL = new SalesERPDAL();
            return userDAL.users.ToList();
        }
        public UserStatus GetUserValidity(UserDetails u)
        {
            SalesERPDAL salesDAL = new SalesERPDAL();
            var LoggedUser = (from d in salesDAL.users
                              where d.UserName == u.UserName && d.Password == u.Password
                              select d).SingleOrDefault();
            if (LoggedUser != null)
            {
                return (UserStatus)LoggedUser.userStatus;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
    }
}