using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwebApp.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserStatus userStatus { get; set; }
    }
}