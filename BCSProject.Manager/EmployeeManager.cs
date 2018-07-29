using BCSProject.Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BCSProject.Manager
{
    public class EmployeeManager
    {
        private readonly string webApiLink = ConfigurationManager.AppSettings["WebApiLinkEmployee"].ToString();
        public JsonSerializer JsonSerializerDateTime = new JsonSerializer() { DateFormatString = "yyyy-MM-dd" };

        public bool CreateEmployee(Employee employee, string token)
        {
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var auth = String.Format($"Bearer {token}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                using (var response = client.PostAsync(webApiLink, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool UpdateEmployee(Employee employee, string token)
        {
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var auth = String.Format($"Bearer {token}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                using (var response = client.PutAsync($"{webApiLink}/{employee.Id}", content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return false;
                    }
                }
            }
            return false;
        }


        public Employee GetEmployee(int id, string token)
        {
            using (var client = new HttpClient())
            {
                var auth = String.Format($"Bearer {token}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                using (var response = client.GetAsync($"{webApiLink}/{id}").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jToken = JToken.Parse(response.Content.ReadAsStringAsync().Result);
                        return jToken.ToObject<Employee>();
                    }
                }
            }
            return null;
        }

        //update fieds for employee
        public bool UpdateEmployeePrivacy()
        {
            return false;
        }

    }
}
