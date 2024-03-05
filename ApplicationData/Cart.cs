using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class Cart
{
    public int CartId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CartsDish> CartsDishes { get; } = new List<CartsDish>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
