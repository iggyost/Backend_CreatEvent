using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Dish> Dishes { get; } = new List<Dish>();
}
