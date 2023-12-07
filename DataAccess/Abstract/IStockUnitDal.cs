using Core.Repository.Abstract;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStockUnitDal : IEntityRepository<StockUnit>
    {
        public List<GetStockUnitDto> GetAllStockUnits();
        public List<GetStockUnitDto> GetAllStockUnitsOnlyActive();
        public List<GetStockUnitDto> GetStockUnitsOnlyActiveByStockTypeId(int id);
        public GetStockUnitDto GetStockUnit(int id);
    }
}
