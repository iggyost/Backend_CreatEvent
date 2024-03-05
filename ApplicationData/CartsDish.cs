using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class CartsDish
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public int DishId { get; set; }

    public int EventId { get; set; }

    public int Count { get; set; }

    public decimal TotalCost { get; set; }

    public bool IsRequested { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Dish Dish { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}
