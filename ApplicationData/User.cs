using System;
using System.Collections.Generic;

namespace Backend_CreatEvent.ApplicationData;

public partial class User
{
    public int UserId { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int CartId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
