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
        public ActionResult LoadRelatedRecords(string selectedTab, int invId)
        {
            if (selectedTab == "OrderLines")
            {
                var model = _dbContext.OrderLines.Where(ol => ol.InvId == invId).ToList();
                return PartialView("_OrderLines", model);
            }
            else
            {
                var model = _dbContext.ShipmentLines.Where(sl => sl.InvId == invId).ToList();
                return PartialView("_ShipmentLines", model);
            }
        }
    }
}
