using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;

namespace TaskManagement.Models.ViewModel
{
    public class TaskModel
    {
        [Required]
        public int TaskID { get; set; }
        [Required]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Enter valid name")]
        public string TaskName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Nullable<System.DateTime> Deadline { get; set; }
        [Required]
        public Nullable<int> CreatorID { get; set; }
    }

    public class TaskList
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public bool Task_complete { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
    }
}
