using System;
using System.Collections.Generic;

namespace The_Ride_You_Rent.models;

public partial class CarBody
{
    public int CarbodyId { get; set; }

    public string? CarBodyDescription { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
