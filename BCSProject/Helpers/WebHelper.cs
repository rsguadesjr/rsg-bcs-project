using System;
using System.Collections.Generic;
using System.Configuration;
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
    }
}