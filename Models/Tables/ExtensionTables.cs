﻿using System;
using System.Collections.Generic;

namespace escale.Models;

public partial class ExtensionTables
{
    public int Id { get; set; }

    public int ParentId { get; set; }

    public string? SortNo { get; set; }

    public string? ExtName { get; set; }

    public string? ExtNo { get; set; }

    public string? Remark { get; set; }
}