using Core.Utilities.Results.Abstract;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStockTypeService
    {
        IResult AddStockType(StockType model);
        IResult UpdateStockType(StockType model);
        IResult ChangeStatus(int id);
        IDataResult<StockType> GetStockTypeById(int id);
        IDataResult<List<StockType>> GetAllStockTypes();
    }
}
