using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCwebApp.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(7, MinimumLength = 2, ErrorMessage = "UserName length should be between 2 and 7")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public int userStatus { get; set; }
    }
}