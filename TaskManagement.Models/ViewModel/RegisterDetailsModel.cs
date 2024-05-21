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
        [MinLength(3, ErrorMessage = "Username must be 3 charecter")]
        [MaxLength(10, ErrorMessage = "Username maximum 10 charecter")]
        [RegularExpression("[a-z]+[0-9]+", ErrorMessage = "Username must Contain Chearacter and Number")]
        public string Username { get; set; }

        [Required]
        
        [RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,}",ErrorMessage ="Enter valid Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(8,ErrorMessage ="Password must be 8 charecter")]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Enter Valid Contect Number")]
        [MaxLength(10, ErrorMessage = "Enter Valid Contect Number")]        
        public string ContactNumber { get; set; }

        [Required(ErrorMessage ="Select State")]
        public Nullable<int> StateID { get; set; }

        [Required(ErrorMessage = "Select City")]
        public Nullable<int> CityID { get; set; }
    }
}