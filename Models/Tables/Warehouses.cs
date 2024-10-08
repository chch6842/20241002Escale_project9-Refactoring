using System;
using System.Collections.Generic;

namespace escale.Models;

public partial class Warehouses
{
    public int Id { get; set; }

    public string? WarehouseNo { get; set; }

    public string? WarehouseName { get; set; }

    public string? Remark { get; set; }
}
