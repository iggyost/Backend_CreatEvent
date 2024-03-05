using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class Request
{
    public int RequestId { get; set; }

    public int UserId { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public int? StatusId { get; set; }

    public virtual Status? Status { get; set; }

    public virtual User User { get; set; } = null!;
}
