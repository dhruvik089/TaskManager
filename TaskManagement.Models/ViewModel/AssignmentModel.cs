using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;

namespace TaskManagement.Models.ViewModel
{
    public class AssignmentModel
    {
        public int AssignmentID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public bool Task_complete { get; set; }

        public virtual Students Students { get; set; }
        public virtual Tasks Tasks { get; set; }
    }

    public class AssignmentList
    {
        public int AssignmentID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public bool Task_complete { get; set; }
        public DateTime Deadline { get; set; }
        public string Username { get; set; }     

    }
}
