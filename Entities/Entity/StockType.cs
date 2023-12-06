using System;
using System.Collections.Generic;

namespace Entities.Entity;

public partial class StockType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsActive { get; set; }
}
