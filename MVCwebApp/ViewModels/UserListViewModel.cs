using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCwebApp.Models;

namespace MVCwebApp.ViewModels
{
    public class UserListViewModel:BaseViewModel
    {
        public List<UserViewModel> users { get; set; }
    }
}