using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class RequestsView
{
    public int RequestId { get; set; }

    public int UserId { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public string Name { get; set; } = null!;
}
