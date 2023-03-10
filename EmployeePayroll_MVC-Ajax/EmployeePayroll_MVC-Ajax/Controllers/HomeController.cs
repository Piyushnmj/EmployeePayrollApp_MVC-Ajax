using EmployeePayroll_MVC_Ajax.Context;
using EmployeePayroll_MVC_Ajax.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll_MVC_Ajax.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor contextAccessor;

        public HomeController(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            contextAccessor.HttpContext.Session.SetString("Employee Name", "Piyush");
            contextAccessor.HttpContext.Session.SetInt32("Employee Id", 1);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
