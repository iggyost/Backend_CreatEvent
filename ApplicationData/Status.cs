using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class Status
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
