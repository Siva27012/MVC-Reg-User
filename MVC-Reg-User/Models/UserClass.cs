using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Reg_User.Models
{
    public class UserClass
    {
        [Required(ErrorMessage = "Enter Username !")]
        [Display(Name = "Enter UserName :")]
        [StringLength(maximumLength:7,MinimumLength = 3,ErrorMessage = "Username Length Must Be Max 7 & Min 3")]
        public string Uname { get; set; }
        public string Uemail { get; set; }
        public string Upwd { get; set; }
        public string Repwd { get; set; }
        public char Gender { get; set; }
        public string Uimg { get; set; }
    }
}