using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.ErrorResults;
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
    public class StockTypeManager : IStockTypeService
    {
        private readonly IStockTypeDal _stockTypeDal;

        public StockTypeManager(IStockTypeDal stockTypeDal)
        {
            _stockTypeDal = stockTypeDal;
        }

        public IResult AddStockType(StockType model)
        {
            _stockTypeDal.Add(model);
            return new SuccessResult(Messages.Added);
        }

        public IResult ChangeStatus(int id)
        {
            var getData = _stockTypeDal.Get(x => x.Id == id);
            if (getData != null)
            {
                _stockTypeDal.ChangeStatus(getData);
                return new SuccessResult(Messages.Succeed);

            }
            return new ErrorResult(Messages.NotFoundData);

        }

        public IDataResult<List<StockType>> GetAllStockTypes()
        {
            var result = _stockTypeDal.GetAll();
            return new SuccessDataResult<List<StockType>>(result, Messages.Listed);
        }

        public IDataResult<StockType> GetStockTypeById(int id)
        {
            var result = _stockTypeDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<StockType>(result, Messages.GetById);
            }
            return new SuccessDataResult<StockType>(Messages.NotFoundData);
        }

        public IResult UpdateStockType(StockType model)
        {
            var getData = _stockTypeDal.Get(x => x.Id == model.Id);
            if (getData != null)
            {
                _stockTypeDal.Update(model);
                return new SuccessResult(Messages.Updated);

            }
            return new ErrorResult(Messages.NotFoundData);
        }
    }
}
