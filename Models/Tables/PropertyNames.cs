using System;
using System.Collections.Generic;

namespace escale.Models;

public partial class PropertyNames
{
    public int Id { get; set; }

    public string? PropName { get; set; }

    public string? DisplayName { get; set; }

    public string? Remark { get; set; }
}
