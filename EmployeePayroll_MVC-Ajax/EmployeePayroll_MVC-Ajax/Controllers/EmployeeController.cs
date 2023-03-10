using EmployeePayroll_MVC_Ajax.Context;
using EmployeePayroll_MVC_Ajax.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace EmployeePayroll_MVC_Ajax.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext objContext;

        public EmployeeController(EmployeeContext objContext)
        {
            this.objContext = objContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployees()
        {
            var data = objContext.PayrollDetails.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddEmployee(EmployeeModel empModel)
        {
            var data = new EmployeeModel()
            {
                EmpName = empModel.EmpName,
                ProfileImg = empModel.ProfileImg,
                Gender = empModel.Gender,
                Department = empModel.Department,
                Salary = empModel.Salary,
                StartDate = empModel.StartDate,
                Notes = empModel.Notes
            };
            objContext.PayrollDetails.Add(data);
            objContext.SaveChanges();
            return new JsonResult("Data Saved");
        }

        public JsonResult EditDetails(int id)
        {
            var data = objContext.PayrollDetails.Where(x => x.EmpID == id).SingleOrDefault();
            return new JsonResult(data);
        }

        public JsonResult UpdateDetails(EmployeeModel empModel)
        {
            objContext.PayrollDetails.Update(empModel);
            objContext.SaveChanges();
            return new JsonResult("Data Updated");
        }

        public JsonResult DeleteDetails(int id)
        {
            var data = objContext.PayrollDetails.Where(x => x.EmpID == id).SingleOrDefault();
            objContext.PayrollDetails.Remove(data);
            objContext.SaveChanges();
            return new JsonResult("Data deleted");
        }
    }
}
