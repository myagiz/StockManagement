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
    public interface IStockService
    {
        IResult AddStock(Stock model);
        IResult UpdateStock(Stock model);
        IResult ChangeStatus(int id);
        IDataResult<List<GetStockDto>> GetAllStocks();
        IDataResult<GetStockDto> GetStock(int id);

    }
}
