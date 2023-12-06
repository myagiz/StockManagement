using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStockUnitService
    {
        IResult AddStockUnit(StockUnit model);
        IResult UpdateStockUnit(StockUnit model);
        IResult ChangeStatus(int id);
        IDataResult<List<GetStockUnitDto>> GetAllStockUnits();
        IDataResult<GetStockUnitDto> GetStockUnit(int id);
    }
}
