using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCwebApp.DataAccessLayer;

namespace MVCwebApp.Models
{
    public class EmployeeBusinessLayer
    {
        public List<UserDetails> GetUsers()
        {
            SalesERPDAL userDAL = new SalesERPDAL();
            return userDAL.users.ToList();
        }
        public List<Employee>GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        public UserStatus GetUserValidity(UserDetails u)
        {
            SalesERPDAL salesDAL = new SalesERPDAL();
            var LoggedUser = (from d in salesDAL.users where d.UserName == u.UserName
                                && d.Password == u.Password select d).SingleOrDefault();
           

            if(LoggedUser != null)
            {
                return (UserStatus)LoggedUser.userStatus;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }

        public void UploadEmployees(List<Employee> employees)
        {
            SalesERPDAL salesDAL = new SalesERPDAL();
            salesDAL.Employees.AddRange(employees);
            salesDAL.SaveChanges();
        }

    }
}