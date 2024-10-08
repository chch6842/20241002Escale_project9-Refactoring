using System;
using System.Collections.Generic;

namespace escale.Models;

public partial class ScaleData
{
    public int Id { get; set; }

    public DateTime RecordDate { get; set; }

    public string? UserNo { get; set; }

    public decimal? Grains { get; set; }

    public decimal? Protein { get; set; }

    public decimal? Dairy { get; set; }

    public decimal? Vegetables { get; set; }

    public decimal? Fruits { get; set; }

    public decimal? OilsNuts { get; set; }
}
