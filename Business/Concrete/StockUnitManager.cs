using Business.Abstract;
using Business.Constants;
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
    }
}
