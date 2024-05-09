using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.ViewModel
{
   public class AssignTaskModel
    {
        public int AssignmentID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<int> CreatorID { get; set; }
    }
}
