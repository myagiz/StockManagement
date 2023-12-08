using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Exception;
using Core.Aspects.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.ErrorResults;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(FileLogger))]
    public class StockManager : IStockService
    {
        private readonly IStockDal _stockDal;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        [ValidationAspect(typeof(StockValidator))]
        public IResult AddStock(Stock model)
        {
            _stockDal.Add(model);
            return new SuccessResult(Messages.Added);
        }

        public IResult ChangeStatus(int id)
        {
            var getData = _stockDal.Get(x => x.Id == id);
            if (getData != null)
            {
                _stockDal.ChangeStatus(getData);
                return new SuccessResult(Messages.Succeed);

            }
            return new ErrorResult(Messages.NotFoundData);
        }

        public IDataResult<List<GetStockDto>> GetAllStocks()
        {
            var result = _stockDal.GetAllStocks();
            return new SuccessDataResult<List<GetStockDto>>(result, Messages.Listed);
        }

        public IDataResult<GetStockDto> GetStock(int id)
        {
            var checkData = _stockDal.Get(x => x.Id == id);
            if (checkData != null)
            {
                var result = _stockDal.GetStock(id);
                return new SuccessDataResult<GetStockDto>(result, Messages.Listed);
            }
            return new ErrorDataResult<GetStockDto>(Messages.NotFoundData);
        }

        //[ValidationAspect(typeof(StockValidator))]
        public IResult UpdateStock(Stock model)
        {
            var getData = _stockDal.Get(x => x.Id == model.Id);
            if (getData != null)
            {
                _stockDal.Update(model);
                return new SuccessResult(Messages.Updated);

            }
            return new ErrorResult(Messages.NotFoundData);
        }
    }
}
