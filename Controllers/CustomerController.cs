using DepartmentStoreApp.Data;
using DepartmentStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;


namespace DepartmentStoreApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DepartmentStoreDbContext _dbContext;
        public CustomerController(DepartmentStoreDbContext context) 
        { 
            _dbContext = context;
        }

        public ActionResult Index()
        {            
            return View();
        }

        public JsonResult GetCustomerData()
        {
            var customersData = _dbContext.Customers.ToList();
            return Json(customersData);
        }
    }
}
