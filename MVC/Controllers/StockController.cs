using Business.Abstract;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    return RedirectToAction("StockType");
                }
                TempData["Error"] = control.Message;
                return RedirectToAction("Index");
            }

            TempData["Error"] = control.Message;
            return RedirectToAction("Index");

        }


        public IActionResult ChangeStatusForStockType(int id)
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
            var result = _stockUnitService.GetAllStockUnits();
            if (result.Success)
            {
                var getStockTypes = _stockTypeService.GetAllStockTypesOnlyActive();
                List<SelectListItem> getDropdownList = (from a in getStockTypes.Data
                                                        select new SelectListItem
                                                        {
                                                            Text = a.Name,
                                                            Value = a.Id.ToString()
                                                        }
                                                     ).ToList();
                ViewBag.StockTypes = getDropdownList;
                return View(new AllStockDto
                {
                    ListStockUnits = result.Data

                });
            }
            return View();
        }

        [HttpPost]
        public IActionResult GetStockUnit(int id)
        {
            var result = _stockUnitService.GetStockUnit(id);
            if (result != null)
            {
                return Json(new AllStockDto
                {
                    GetStockUnit = result.Data
                });
            }
            TempData["Error"] = result.Message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddStockUnit(AllStockDto model)
        {
            var entity = new StockUnit
            {
                Code = model.StockUnit.Code,
                StockType = model.StockUnit.StockType,
                UnitId = model.StockUnit.UnitId,
                Description = model.StockUnit.Description,
                Paperweight = model.StockUnit.Paperweight,
                PurchaseCurrencyId = model.StockUnit.PurchaseCurrencyId,
                PurchasePrice = model.StockUnit.PurchasePrice,
                SaleCurrencyId = model.StockUnit.SaleCurrencyId,
                SalePrice = model.StockUnit.SalePrice,
            };

            var result = _stockUnitService.AddStockUnit(entity);
            if (result.Success)
            {
                return RedirectToAction("StockUnit");
            }
            TempData["Error"] = result.Message;
            return RedirectToAction("Index");
        }

        public IActionResult UpdateStockUnit(AllStockDto model)
        {
            var control = _stockUnitService.GetStockUnit(model.GetStockUnit.Id);
            if (control.Success)
            {

                var entity = new StockUnit
                {
                    Id = model.GetStockUnit.Id,
                    Code = model.GetStockUnit.Code,
                    StockType = model.GetStockUnit.StockType,
                    UnitId = model.GetStockUnit.UnitId,
                    Description = model.GetStockUnit.Description,
                    Paperweight = model.GetStockUnit.Paperweight,
                    PurchaseCurrencyId = model.GetStockUnit.PurchaseCurrencyId,
                    PurchasePrice = model.GetStockUnit.PurchasePrice,
                    SaleCurrencyId = model.GetStockUnit.SaleCurrencyId,
                    SalePrice = model.GetStockUnit.SalePrice,
                };

                var updateMethod = _stockUnitService.UpdateStockUnit(entity);
                if (updateMethod.Success)
                {
                    return RedirectToAction("StockUnit");
                }
                TempData["Error"] = control.Message;
                return RedirectToAction("Index");
            }

            TempData["Error"] = control.Message;
            return RedirectToAction("Index");

        }


        public IActionResult ChangeStatusForStockUnit(int id)
        {
            var result = _stockUnitService.ChangeStatus(id);
            if (result.Success)
            {
                return RedirectToAction("StockUnit");
            }
            TempData["Error"] = result.Message;
            return RedirectToAction("Index");
        }


    }
}
