using BCSProject.Data.Common;
using BCSProject.Helpers;
using BCSProject.Manager;
using BCSProject.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace BCSProject.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private AuthenticationService authService;
        private EmployeeManager employeeManager;
        private EmployeePrivacyManager employeePrivacyManager;
        public EmployeesController()
        {
            authService = new AuthenticationService(System.Web.HttpContext.Current);
            employeeManager = new EmployeeManager();
            employeePrivacyManager = new EmployeePrivacyManager();
        }

        // GET: Employees
        public ActionResult Index()
        {
            ViewBag.AccessToken = authService.AccessToken();
            return View();
        }

        // GET: 
        //make an custom attribute
        [Authorize(Roles = UserType.Admin + "," + UserType.Editor)]
        public ActionResult Edit(int id)

        {
            var employee = employeeManager.GetEmployee(id, authService.AccessToken());
            var viewModel = new EmployeeViewModel().ParseToViewModel(employee);
            return View(viewModel);
        }

        [Authorize(Roles = UserType.Admin + "," + UserType.Editor)]
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel viewModel)
        {
            var employee = viewModel.ParseToDataModel(viewModel);
            var saved = employeeManager.UpdateEmployee(employee, authService.AccessToken());
            if (saved)
            {
                return RedirectToAction("Index", "Employees");
            }
            return View(viewModel);
        }

        [Authorize(Roles = UserType.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public ActionResult Create(EmployeeViewModel viewModel)
        {
            var employee = viewModel.ParseToDataModel(viewModel);
            var saved = employeeManager.CreateEmployee(employee, authService.AccessToken());
            if (saved)
            {
                return RedirectToAction("Index", "Employees");
            }
            return View(viewModel);
        }


        // Edit Privacy
        public ActionResult EditPrivacy(int id)
        {
            var model = employeePrivacyManager.GetEmployeeFields(id, authService.AccessToken());
            var viewModel = new PrivacyEmployeeViewModel().ParseToViewModel(model);
            return View(viewModel);
        }


        // Edit Privacy
        [HttpPost]
        public ActionResult EditPrivacy(List<PrivacyEmployeeViewModel> viewModel)
        {
            return View(viewModel);
        }
    }
}