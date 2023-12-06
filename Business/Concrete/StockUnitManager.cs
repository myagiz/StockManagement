using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StockUnitManager : IStockUnitService
    {
        private readonly IStockUnitDal _stockUnitDal;

        public StockUnitManager(IStockUnitDal stockUnitDal)
        {
            _stockUnitDal = stockUnitDal;
        }

        public IResult AddStockUnit(StockUnit model)
        {
            _stockUnitDal.Add(model);
            return new SuccessResult(Messages.Added);
        }
    }
}
