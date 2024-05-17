﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Common
{
    public class WebApiHelper
    {
        public async static Task<List<AssignmentList>> StudentCallApi(int studentId,string action)
        {
            List<AssignmentList> _assignments=new List<AssignmentList>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59647/api/student");
            HttpResponseMessage response = await client.GetAsync($"student/{action}?id={studentId}");


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                _assignments = JsonConvert.DeserializeObject<List<AssignmentList>>(data);
            }
            return _assignments;
        }

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
    }
}