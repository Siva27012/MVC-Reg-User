using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVC_Reg_User.Models
{
    public class UserClass
    {
        [Required(ErrorMessage = "Enter Username !")]
        [Display(Name = "Enter UserName :")]
        [StringLength(maximumLength:7,MinimumLength = 3,ErrorMessage = "Username Length Must Be Max 7 & Min 3")]
        public string Uname { get; set; }

        [Required(ErrorMessage = "Please Enter The Email Address !")]
        [Display(Name = "Email Id :")]
        public string Uemail { get; set; }

        [Required(ErrorMessage = "Enter The Password !")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Upwd { get; set; }

        [Required(ErrorMessage = "Enter The RePassword !")]
        [Display(Name = "Re-Password :")]
        [DataType(DataType.Password)]
        [Compare("Upwd")]
        public string Repwd { get; set; }

        [Required(ErrorMessage = "Select The Gender !")]
        [Display(Name = "Gender :")]
        public char Gender { get; set; }

        [Required(ErrorMessage = "Upload Profile Image !")]
        [Display(Name = "Profile Image :")]
        public string Uimg { get; set; }
    }
}