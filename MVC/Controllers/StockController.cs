using Business.Abstract;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockTypeService _stockTypeService;

        private readonly IStockUnitService _stockUnitService;

        public StockController(IStockTypeService stockTypeService, IStockUnitService stockUnitService)
        {
            _stockTypeService = stockTypeService;
            _stockUnitService = stockUnitService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Stock Type Methods
        /// </summary>
        /// <returns></returns>
        public IActionResult StockType()
        {
            var result = _stockTypeService.GetAllStockTypes();
            if (result.Success)
            {
                return View(new AllStockDto
                {
                    ListStockTypes = result.Data

                });
            }
            return View();
        }

        [HttpPost]
        public IActionResult GetStockTypeById(int id)
        {
            var result = _stockTypeService.GetStockTypeById(id);
            if (result != null)
            {
                return Json(new AllStockDto
                {
                    StockType = result.Data
                });
            }
            TempData["Error"] = result.Message;
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult AddStockType(AllStockDto model)
        {
            var entity = new StockType
            {
                Name = model.StockType.Name
            };

            var result = _stockTypeService.AddStockType(entity);
            if (result.Success)
            {
                return RedirectToAction("StockType");
            }
            TempData["Error"] = result.Message;
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult UpdateStockType(AllStockDto model)
        {
            var control = _stockTypeService.GetStockTypeById(model.StockType.Id);
            if (control.Success)
            {

                var entity = new StockType
                {
                    Id = model.StockType.Id,
                    Name = model.StockType.Name,
                };

                var updateMethod = _stockTypeService.UpdateStockType(entity);
                if (updateMethod.Success)
                {
                    return RedirectToAction("Index");
                }
                TempData["Error"] = control.Message;
                return RedirectToAction("Index");
            }

            TempData["Error"] = control.Message;
            return RedirectToAction("Index");

        }


        public IActionResult ChangeStatus(int id)
        {
            var result = _stockTypeService.ChangeStatus(id);
            if (result.Success)
            {
                return RedirectToAction("StockType");
            }
            TempData["Error"] = result.Message;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Stock Unit Methods
        /// </summary>
        /// <returns></returns>
        public IActionResult StockUnit()
        {
            var result = _stockUnitService.GetAllStockTypes();
            if (result.Success)
            {
                return View(new AllStockDto
                {
                    ListStockTypes = result.Data

                });
            }
            return View();
        }

    }
}
