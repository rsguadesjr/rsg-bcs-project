using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCSProject.Helpers
{
    public class WebHelper
    {
        public static string WebApiLink = ConfigurationManager.AppSettings["WebApiLink"].ToString();

        private static SelectListItem _blankListItem = new SelectListItem { Value = String.Empty, Text = String.Empty };

        public static List<SelectListItem> GetUserRoles()
        {
            return new List<SelectListItem>(){
                _blankListItem,
                new SelectListItem { Value = "1", Text = "Admin"},
                new SelectListItem { Value = "2", Text = "Employee"},
                new SelectListItem { Value = "3", Text = "Editor"},
                new SelectListItem { Value = "4", Text = "Viewer"}
            };
        }

        public static List<SelectListItem> Gender()
        {
            return new List<SelectListItem>()
            {
                _blankListItem,
                new SelectListItem { Value = "M", Text = "Male"},
                new SelectListItem { Value = "F", Text = "Female"}
            };
        }

        public static List<SelectListItem> CivilStatus()
        {
            return new List<SelectListItem>()
            {
                _blankListItem,
                new SelectListItem{ Value = "Single", Text = "Single" },
                new SelectListItem{ Value = "Married", Text = "Married" },
                new SelectListItem{ Value = "Divorced", Text = "Divorced" },
                new SelectListItem{ Value = "Separated", Text = "Separated" },
                new SelectListItem{ Value = "Widowed", Text = "Widowed" },
            };
        }

        public static List<SelectListItem> PrivatePublicOptions(bool isPublic)
        {
            return new List<SelectListItem>()
            {
                new SelectListItem{ Value = "true", Text = "Public", Selected = isPublic },
                new SelectListItem{ Value = "false", Text = "Private", Selected = !isPublic }
            };
        }

        public static List<SelectListItem> Countries()
        {
            JToken json;
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/Content/JsonApis/countries.json")))
            {
                string jsonData = r.ReadToEnd();
                json = JToken.Parse(jsonData);
            }
            var list = new List<SelectListItem>();
            for (int i = 0; i < json.Count(); i++)
            {
                list.Add(
                    new SelectListItem {
                        Value = json[i]["code"].ToString(),
                        Text = json[i]["name"].ToString()
                    });
            }
            list.Insert(0, _blankListItem);
            return list;
        }
    }
}