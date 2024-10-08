using System;
using System.Collections.Generic;

namespace escale.Models;

public partial class Notifications
{
    public int Id { get; set; }

    public bool IsRead { get; set; }

    public string? CodeNo { get; set; }

    public string? SourceNo { get; set; }

    public string? SenderNo { get; set; }

    public string? ReceiverNo { get; set; }

    public DateOnly SendDate { get; set; }

    public DateOnly SendTime { get; set; }

    public string? HeaderText { get; set; }

    public string? MessageText { get; set; }

    public string? Remark { get; set; }
}
