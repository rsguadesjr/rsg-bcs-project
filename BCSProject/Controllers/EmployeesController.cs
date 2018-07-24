using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCSProject.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        // GET: 
        public ActionResult Edit(int id)
        {
            ViewBag.EmployeeId = id;
            return View();
        }

        // Edit Privacy
        public ActionResult EditPrivacy(int id)
        {
            return View();
        }

        
    }
}