using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using BCSProject.Data;

namespace BCSProject.Manager
{
    public class UserManager
    {
        string webApiLink = ConfigurationManager.AppSettings["WebApiLinkToken"];

        public Token GetAccessToken(string username, string password)
        {
            var content = new FormUrlEncodedContent(TokenBody(username, password));
            using (var client = new HttpClient())
            {
                using (var response = client.PostAsync(webApiLink, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var apiResponse = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                            return new Token {
                               AccessToken = apiResponse["access_token"].ToString(),
                               Expiration = DateTime.Now.AddSeconds(int.Parse(apiResponse["expires_in"].ToString()))
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
