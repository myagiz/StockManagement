using Core.Repository.Concrete;
using DataAccess.Abstract;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreStockUnitDal : EfEntityRepository<StockUnit, StockManagementContext>, IStockUnitDal
    {
    }
}
