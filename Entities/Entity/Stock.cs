using System;
using System.Collections.Generic;

namespace Entities.Entity;

public partial class Stock
{
    public int Id { get; set; }

    public int StockType { get; set; }

    public int StockUnit { get; set; }

    public decimal Quantity { get; set; }

    public decimal CriticalQuantity { get; set; }

    public string ShelfInfo { get; set; }

    public string CabinetInfo { get; set; }

    public bool IsActive { get; set; }
}
