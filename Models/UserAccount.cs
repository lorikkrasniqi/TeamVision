using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace VisionStore.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }


        [Required (ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType (DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }




        [Required(ErrorMessage = "Birthplace is required")]
        public string Birthplace { get; set; }



        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        public DateOnly Birthday { get; set; }  




    }
}
