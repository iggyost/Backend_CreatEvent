using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class Event
{
    public int EventId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string CoverPhoto { get; set; } = null!;

    public virtual ICollection<CartsDish> CartsDishes { get; } = new List<CartsDish>();
}
