using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;

namespace TaskManagement.Models.ViewModel
{
    public class TaskModel
    {

        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<int> CreatorID { get; set; }
    }
}
