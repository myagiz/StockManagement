using System;
using System.Collections.Generic;

namespace Entities.Entity;

public partial class StockUnit
{
    public int Id { get; set; }

    public string Code { get; set; }

    public int StockType { get; set; }

    public int UnitId { get; set; }

    public string Description { get; set; }

    public decimal? Paperweight { get; set; }

    public int PurchaseCurrencyId { get; set; }

    public decimal? PurchasePrice { get; set; }

    public int SaleCurrencyId { get; set; }

    public decimal? SalePrice { get; set; }

    public bool IsActive { get; set; }
}
