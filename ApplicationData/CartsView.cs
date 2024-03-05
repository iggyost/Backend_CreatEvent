using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class CartsView
{
    public int UserId { get; set; }

    public int CartId { get; set; }

    public int DishId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string CoverPhoto { get; set; } = null!;

    public decimal Cost { get; set; }

    public int Id { get; set; }

    public int Count { get; set; }

    public decimal TotalCost { get; set; }

    public int EventId { get; set; }

    public bool IsRequested { get; set; }
}
