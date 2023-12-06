using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AllStockDto
    {
        public List<StockType> ListStockTypes { get; set; }
        public List<GetStockUnitDto> ListStockUnits { get; set; }
        public List<Stock> ListStocks { get; set; }
        public StockType StockType { get; set; }
        public StockUnit StockUnit { get; set; }
        public GetStockUnitDto GetStockUnit { get; set; }
        public Stock Stock { get; set; }
    }
}
