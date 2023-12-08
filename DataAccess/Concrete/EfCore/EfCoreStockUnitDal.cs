using Core.Extensions;
using Core.Repository.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entity;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreStockUnitDal : EfEntityRepository<StockUnit, StockManagementContext>, IStockUnitDal
    {
        public List<GetStockUnitDto> GetAllStockUnits()
        {
            using (var context = new StockManagementContext())
            {
                var data = (from a in context.StockUnits
                            join b in context.StockTypes on a.StockType equals b.Id
                            select new GetStockUnitDto
                            {
                                Id = a.Id,
                                Code = a.Code,
                                StockType = a.StockType,
                                StockTypeName = b.Name,
                                UnitId = a.UnitId,
                                UnitName = EnumExtensions.GetEnumDescription((UnitTypes)a.UnitId),
                                Description = a.Description,
                                Paperweight = a.Paperweight,
                                PurchaseCurrencyId = a.PurchaseCurrencyId,
                                PurchaseCurrencyName = EnumExtensions.GetEnumDescription((CurrencyTypes)a.PurchaseCurrencyId),
                                PurchasePrice = a.PurchasePrice,
                                SaleCurrencyId = a.SaleCurrencyId,
                                SaleCurrencyName = EnumExtensions.GetEnumDescription((CurrencyTypes)a.PurchaseCurrencyId),
                                SalePrice = a.SalePrice,
                                IsActive = a.IsActive,
                            }

                          ).OrderByDescending(x => x.Id).ToList();
                return data;
            }
        }

        public List<GetStockUnitDto> GetAllStockUnitsOnlyActive()
        {
            using (var context = new StockManagementContext())
            {
                var data = (from a in context.StockUnits.Where(x => x.IsActive == true)
                            join b in context.StockTypes on a.StockType equals b.Id
                            select new GetStockUnitDto
                            {
                                Id = a.Id,
                                Code = a.Code,
                                StockType = a.StockType,
                                StockTypeName = b.Name,
                                UnitId = a.UnitId,
                                UnitName = EnumExtensions.GetEnumDescription((UnitTypes)a.UnitId),
                                Description = a.Description,
                                Paperweight = a.Paperweight,
                                PurchaseCurrencyId = a.PurchaseCurrencyId,
                                PurchaseCurrencyName = EnumExtensions.GetEnumDescription((CurrencyTypes)a.PurchaseCurrencyId),
                                PurchasePrice = a.PurchasePrice,
                                SaleCurrencyId = a.SaleCurrencyId,
                                SaleCurrencyName = EnumExtensions.GetEnumDescription((CurrencyTypes)a.PurchaseCurrencyId),
                                SalePrice = a.SalePrice,
                                IsActive = a.IsActive,
                            }

                          ).OrderByDescending(x => x.Id).ToList();
                return data;
            }
        }

        public GetStockUnitDto GetStockUnit(int id)
        {
            using (var context = new StockManagementContext())
            {
                var data = (from a in context.StockUnits.Where(x => x.Id == id)
                            join b in context.StockTypes on a.StockType equals b.Id
                            select new GetStockUnitDto
                            {
                                Id = a.Id,
                                Code = a.Code,
                                StockType = a.StockType,
                                StockTypeName = b.Name,
                                UnitId = a.UnitId,
                                UnitName = EnumExtensions.GetEnumDescription((UnitTypes)a.UnitId),
                                Description = a.Description,
                                Paperweight = a.Paperweight,
                                PurchaseCurrencyId = a.PurchaseCurrencyId,
                                PurchaseCurrencyName = EnumExtensions.GetEnumDescription((CurrencyTypes)a.PurchaseCurrencyId),
                                PurchasePrice = a.PurchasePrice,
                                SaleCurrencyId = a.SaleCurrencyId,
                                SaleCurrencyName = EnumExtensions.GetEnumDescription((CurrencyTypes)a.PurchaseCurrencyId),
                                SalePrice = a.SalePrice,
                                IsActive = a.IsActive,
                            }

                          ).FirstOrDefault();
                return data;
            }
        }

        public List<GetStockUnitDto> GetStockUnitsOnlyActiveByStockTypeId(int id)
        {
            using (var context = new StockManagementContext())
            {
                var data = (from a in context.StockUnits.Where(x => x.IsActive == true && x.StockType == id)
                            join b in context.StockTypes on a.StockType equals b.Id
                            select new GetStockUnitDto
                            {
                                Id = a.Id,
                                Code = a.Code,
                                StockType = a.StockType,
                                StockTypeName = b.Name,
                                UnitId = a.UnitId,
                                UnitName = EnumExtensions.GetEnumDescription((UnitTypes)a.UnitId),
                                Description = a.Description,
                                Paperweight = a.Paperweight,
                                PurchaseCurrencyId = a.PurchaseCurrencyId,
                                PurchaseCurrencyName = EnumExtensions.GetEnumDescription((CurrencyTypes)a.PurchaseCurrencyId),
                                PurchasePrice = a.PurchasePrice,
                                SaleCurrencyId = a.SaleCurrencyId,
                                SaleCurrencyName = EnumExtensions.GetEnumDescription((CurrencyTypes)a.PurchaseCurrencyId),
                                SalePrice = a.SalePrice,
                                IsActive = a.IsActive,
                            }

                          ).OrderByDescending(x => x.Id).ToList();
                return data;
            }
        }
    }
}
