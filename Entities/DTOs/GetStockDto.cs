using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GetStockDto
    {
        public int Id { get; set; }

        public int StockType { get; set; }

        public string StockTypeName { get; set; }

        public string UnitName { get; set; }

        public string Code { get; set; }

        public int StockUnit { get; set; }

        public string StockUnitName { get; set; }

        public decimal Quantity { get; set; }

        public decimal CriticalQuantity { get; set; }

        public string ShelfInfo { get; set; }

        public string CabinetInfo { get; set; }

        public bool IsActive { get; set; }
    }
}
