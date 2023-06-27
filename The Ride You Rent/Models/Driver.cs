using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;

namespace The_Ride_You_Rent.models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string DName { get; set; } = null!;

    public string DAddress { get; set; } = null!;

    public string DEmail { get; set; } = null!;

    public int DMobile { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Return1> Returns { get; set; } = new List<Return1>();
}
