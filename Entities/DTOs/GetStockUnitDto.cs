using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GetStockUnitDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int StockType { get; set; }

        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public string Description { get; set; }

        public decimal? Paperweight { get; set; }

        public int PurchaseCurrencyId { get; set; }

        public string PurchaseCurrencyName { get; set; }

        public decimal? PurchasePrice { get; set; }

        public int SaleCurrencyId { get; set; }

        public string SaleCurrencyName { get; set; }

        public decimal? SalePrice { get; set; }

        public bool IsActive { get; set; }
    }
}
