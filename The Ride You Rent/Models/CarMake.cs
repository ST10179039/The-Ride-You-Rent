using System;
using System.Collections.Generic;

namespace The_Ride_You_Rent.models;

public partial class CarMake
{
    public int CarMakeId { get; set; }

    public string? CDescription { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
