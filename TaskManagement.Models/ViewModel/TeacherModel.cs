using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.ViewModel
{
    public class TeacherModel
    {
        public int TeacherID { get; set; }
        public string UserRole {  get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }
    }
}
