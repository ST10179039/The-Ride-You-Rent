using System;
using System.Collections.Generic;

namespace The_Ride_You_Rent.models;

public partial class Rental
{
    public int RentalId { get; set; }

    public string CarNo { get; set; } = null!;

    public string IName { get; set; } = null!;

    public string DName { get; set; } = null!;

    public int RentalFee { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? CarId { get; set; }

    public int? InspectorId { get; set; }

    public int? DriverId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Inspector? Inspector { get; set; }
}
