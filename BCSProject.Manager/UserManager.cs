using BCSProject.Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace BCSProject.Manager
{
    public class UserManager
    {
        private readonly string webApiLinkToken = ConfigurationManager.AppSettings["WebApiLinkToken"];
        private readonly string webApiLink = ConfigurationManager.AppSettings["WebApiLink"];

        public User Login(string username, string password)
        {

            var json = JsonConvert.SerializeObject(new { Username = username, Password = password});
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                using (var response = client.PostAsync(webApiLink + "api/users/login", content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var apiResponse = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                            return new User
                            {
                                Username = apiResponse["username"].ToString(),
                                Role = new Role {
                                        RoleName = (string)apiResponse.SelectToken("role.roleName")
                                }
                            };
                        }
                        catch (Exception err)
                        {
                            Debug.WriteLine(err.Message);
                        }
                    }
                }
            }
            return null;
        }

        public Token GetAccessToken(string username, string password)
        {
            var content = new FormUrlEncodedContent(TokenBody(username, password));
            using (var client = new HttpClient())
            {
                using (var response = client.PostAsync(webApiLinkToken, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var apiResponse = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                            return new Token {
                               AccessToken = apiResponse["access_token"].ToString(),
                               Expiration = DateTime.Now.AddSeconds(int.Parse(apiResponse["expires_in"].ToString())),
                               //Role = apiResponse["role"].ToString()
                            };
                        }
                        catch (Exception err)
                        {
                            Debug.WriteLine(err.Message);
                        }
                    }
                }
            }
            return null;
        }

        public List<KeyValuePair<string, string>> TokenBody(string username, string password)
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>( "grant_type", "password" ),
                new KeyValuePair<string, string>( "username", username ),
                new KeyValuePair<string, string> ( "password", password )
            };
        }
    }
}
