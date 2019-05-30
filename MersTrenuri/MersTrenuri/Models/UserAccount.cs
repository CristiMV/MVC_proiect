using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MersTrenuri.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]

        public String Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public String Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Compare("Password", ErrorMessage ="Please confirm your password")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }

    }
}