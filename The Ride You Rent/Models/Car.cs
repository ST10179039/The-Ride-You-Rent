using System;
using System.Collections.Generic;

namespace The_Ride_You_Rent.models;

public partial class Car
{
    public int CarId { get; set; }

    public string CarNo { get; set; } = null!;

    public string CDescription { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public string CarBodyDescription { get; set; } = null!;

    public int KmTravelled { get; set; }

    public int ServiceKm { get; set; }

    public string Availability { get; set; } = null!;

    public int? CarMakeId { get; set; }

    public int? CarbodyId { get; set; }

    public virtual CarMake? CarMake { get; set; }

    public virtual CarBody? Carbody { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Return1> Returns { get; set; } = new List<Return1>();
}
