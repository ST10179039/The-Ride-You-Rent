using System;
using System.Collections.Generic;

namespace The_Ride_You_Rent.models;

public partial class Inspector
{
    public int InspectorId { get; set; }

    public string InspectorNo { get; set; } = null!;

    public string IName { get; set; } = null!;

    public string IEmail { get; set; } = null!;

    public int IMobile { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Return1> Returns { get; set; } = new List<Return1>();
}
