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
    public class EfCoreStockDal : EfEntityRepository<Stock, StockManagementContext>, IStockDal
    {
        public List<GetStockDto> GetAllStocks()
        {
            using (var context = new StockManagementContext())
            {
                var data = (from a in context.Stocks
                            join b in context.StockTypes on a.StockType equals b.Id
                            join c in context.StockUnits on a.StockUnit equals c.Id
                            select new GetStockDto
                            {
                                Id = a.Id,
                                Code = c.Code,
                                StockType = a.StockType,
                                StockTypeName = b.Name,
                                StockUnit = c.UnitId,
                                StockUnitName = "",
                                Quantity = a.Quantity,
                                CriticalQuantity = a.CriticalQuantity,
                                ShelfInfo = a.ShelfInfo,
                                CabinetInfo = a.CabinetInfo,
                                IsActive = a.IsActive,
                            }

                          ).OrderByDescending(x => x.Id).ToList();
                return data;
            }
        }

        public GetStockDto GetStock(int id)
        {
            using (var context = new StockManagementContext())
            {
                var data = (from a in context.Stocks.Where(x => x.Id == id)
                            join b in context.StockTypes on a.StockType equals b.Id
                            join c in context.StockUnits on a.StockUnit equals c.Id
                            select new GetStockDto
                            {
                                Id = a.Id,
                                Code = c.Code,
                                StockType = a.StockType,
                                StockTypeName = b.Name,
                                StockUnit = c.UnitId,
                                StockUnitName = "",
                                Quantity = a.Quantity,
                                CriticalQuantity = a.CriticalQuantity,
                                ShelfInfo = a.ShelfInfo,
                                CabinetInfo = a.CabinetInfo,
                                IsActive = a.IsActive,
                            }

                          ).FirstOrDefault();
                return data;
            }
        }
    }
}
