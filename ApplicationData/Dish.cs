using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class Dish
{
    public int DishId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string CoverPhoto { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<CartsDish> CartsDishes { get; } = new List<CartsDish>();

    public virtual Category Category { get; set; } = null!;
}
