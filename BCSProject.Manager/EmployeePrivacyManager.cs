using BCSProject.Data.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BCSProject.Manager
{

    public class EmployeePrivacyManager
    {
        private readonly string webApiLink = ConfigurationManager.AppSettings["WebApiLink"].ToString();

        public List<EmployeeCharacteristic> GetEmployeeFields(int id, string token)
        {
            using (var client = new HttpClient())
            {
                var auth = String.Format($"Bearer {token}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                using (var response = client.GetAsync($"{webApiLink}api/characteristics/{id}").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jToken = JToken.Parse(response.Content.ReadAsStringAsync().Result);
                        return jToken.ToObject<List<EmployeeCharacteristic>>();
                    }
                }
            }
            return null;
        }
    }
}
