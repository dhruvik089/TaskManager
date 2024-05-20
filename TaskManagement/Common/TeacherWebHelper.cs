using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Common
{
    public class TeacherWebHelper
    {
       
        public async static Task<List<TaskList>> TeacherCallApi(int teacherId, string action)
        {
            List<TaskList> _teachers = new List<TaskList>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59647/api/teacher");
            HttpResponseMessage response = await client.GetAsync($"teacher/{action}?id={teacherId}");
            
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                _teachers = JsonConvert.DeserializeObject<List<TaskList>>(data);
            }
            return _teachers;
        }

        public async static Task<int> DeleteTask(int id)
        {
            int temp=-1;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59647/api/teacher");
            HttpResponseMessage response = await client.GetAsync($"teacher/DeleteTask?id={id}");

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                temp = JsonConvert.DeserializeObject<int>(data);

            }
            return temp;
        }
   
        public async static Task<List<StudentModel>> NotAssignTask(int teacherId, string action)
        {
            List<StudentModel> _studentList = new List<StudentModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59647/api/teacher");
            HttpResponseMessage response = await client.GetAsync($"teacher/{action}?id={teacherId}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                _studentList = JsonConvert.DeserializeObject<List<StudentModel>>(data);
            }
            return _studentList;
        }

        public async static Task<List<Assignment>> AssignTask(List<AssignmentModel> assignments, string action)
        {
            List<Assignment> _assignments = new List<Assignment>();
            HttpClient client = new HttpClient();
            string content = JsonConvert.SerializeObject(assignments);
            client.BaseAddress = new Uri("http://localhost:59647/api/teacher");
            HttpResponseMessage response = await client.PostAsync($"teacher/{action}", new StringContent(content, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                _assignments = JsonConvert.DeserializeObject<List<Assignment>>(data);
            }
            return _assignments;
        }

        public async static Task<Tasks> CreateTask(TaskModel _taskModel, string action)
        {
            Tasks _task = new Tasks();
            HttpClient client = new HttpClient();
            string content = JsonConvert.SerializeObject(_taskModel);
            client.BaseAddress = new Uri("http://localhost:59647/api/teacher");
            HttpResponseMessage response = await client.PostAsync($"teacher/{action}", new StringContent(content, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                _task = JsonConvert.DeserializeObject<Tasks>(data);
            }
            return _task;
        }

    }
}