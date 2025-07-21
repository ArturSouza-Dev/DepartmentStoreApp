using DepartmentStoreApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStoreApp.Controllers
{
    public class InventoryController : Controller
    {
        private readonly DepartmentStoreDbContext _dbContext;

        public InventoryController(DepartmentStoreDbContext context) 
        { 
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetInventoryData()
        {
            var inventoryData = _dbContext.Inventories.ToList();
            return Json(inventoryData);
        }

        [HttpGet]
        public ActionResult LoadInventoryOrderLines()
        {
            var model = _dbContext.OrderLines.ToList();
            return PartialView("_OrderLines", model);
        }

        [HttpGet]
        public ActionResult LoadInventoryShipmentLines()
        {
            var model = _dbContext.ShipmentLines.ToList();
            return PartialView("_ShipmentLines", model);
        }
    }
}
