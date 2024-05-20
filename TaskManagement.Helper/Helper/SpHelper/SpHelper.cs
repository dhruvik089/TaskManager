using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Helper.Helper.SpHelper
{
    public class SpHelper
    {
        public static string ShowAssignment = "Exec ShowAssignment @id";
        public static string totalCompleteTask = "exec totalCompleteTask @id";
        public static string StudentExpiredTask = "exec StudentExpiredTask @id";
        public static string totalPendingTask = "exec totalPendingTask @id";
        public static string TotalCreatTask = "exec TotalCreatTask @id";
        public static string TeacherCompleteTask = "exec TeacherCompleteTask @id";
        public static string TeacherPendingTask = "exec TeacherPendingTask @id";
        public static string TotalAssignTask = "exec TotalAssignTask @id";
        public static string TeacherExpiredTask = "exec TeacherExpiredTask @id";
        public static string DeleteTask = "exec DeleteTask @id";
        public static string GetStudentByTaskNotAssign = "exec GetStudentByTaskNotAssign @id";
        public static string AssignAssignment = "exec AssignAssignment @Taskid @Studentid";
    }
}
