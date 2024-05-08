using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagement.Models.ViewModel
{
    public class RegisterDetailsModel
    {
        [Required]
        public string UserRole { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public Nullable<int> StateID { get; set; }
        [Required]
        public Nullable<int> CityID { get; set; }
    }
}