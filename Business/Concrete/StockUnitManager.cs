using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Exception;
using Core.Aspects.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.ErrorResults;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(FileLogger))]
    public class StockUnitManager : IStockUnitService
    {
        private readonly IStockUnitDal _stockUnitDal;

        public StockUnitManager(IStockUnitDal stockUnitDal)
        {
            _stockUnitDal = stockUnitDal;
        }

        [ValidationAspect(typeof(StockUnitValidator))]
        public IResult AddStockUnit(StockUnit model)
        {
            IResult result = BusinessRules.Run(CheckIfUserCodeExists(model.Code));
            if (result == null)
            {
                _stockUnitDal.Add(model);
                return new SuccessResult(Messages.Added);
            }

            return new ErrorResult(Messages.AlreadyExists);

        }

        public IResult ChangeStatus(int id)
        {
            var getData = _stockUnitDal.Get(x => x.Id == id);
            if (getData != null)
            {
                _stockUnitDal.ChangeStatus(getData);
                return new SuccessResult(Messages.Succeed);

            }
            return new ErrorResult(Messages.NotFoundData);
        }

        public IDataResult<List<GetStockUnitDto>> GetAllStockUnits()
        {
            var result = _stockUnitDal.GetAllStockUnits();
            return new SuccessDataResult<List<GetStockUnitDto>>(result, Messages.Listed);
        }

        public IDataResult<List<GetStockUnitDto>> GetAllStockUnitsOnlyActive()
        {
            var result = _stockUnitDal.GetAllStockUnitsOnlyActive();
            return new SuccessDataResult<List<GetStockUnitDto>>(result, Messages.Listed);
        }

        public IDataResult<GetStockUnitDto> GetStockUnit(int id)
        {
            var checkData = _stockUnitDal.Get(x => x.Id == id);
            if (checkData != null)
            {
                var result = _stockUnitDal.GetStockUnit(id);
                return new SuccessDataResult<GetStockUnitDto>(result, Messages.Listed);
            }
            return new ErrorDataResult<GetStockUnitDto>(Messages.NotFoundData);
        }

        public IDataResult<List<GetStockUnitDto>> GetStockUnitsOnlyActiveByStockTypeId(int id)
        {
            var result = _stockUnitDal.GetStockUnitsOnlyActiveByStockTypeId(id);
            return new SuccessDataResult<List<GetStockUnitDto>>(result, Messages.Listed);
        }

        //[ValidationAspect(typeof(StockUnitValidator))]
        public IResult UpdateStockUnit(StockUnit model)
        {
            var getData = _stockUnitDal.Get(x => x.Id == model.Id);
            if (getData != null)
            {
                _stockUnitDal.Update(model);
                return new SuccessResult(Messages.Updated);

            }
            return new ErrorResult(Messages.NotFoundData);
        }

        private IResult CheckIfUserCodeExists(string code)
        {
            var result = _stockUnitDal.GetAll(x => x.Code == code).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }
            return new SuccessResult();
        }

    }
}
