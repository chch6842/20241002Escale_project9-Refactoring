using System;
using System.Collections.Generic;

namespace escale.Models;

public partial class WorkflowRoles
{
    public int Id { get; set; }

    public string? RoleNo { get; set; }

    public string? RoleName { get; set; }

    public string? Remark { get; set; }
}
