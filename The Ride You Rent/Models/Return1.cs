using System;
using System.Collections.Generic;

namespace The_Ride_You_Rent.models;

public partial class Return1
{
    public int ReturnId { get; set; }

    public string CarNo { get; set; } = null!;

    public string IName { get; set; } = null!;

    public string DName { get; set; } = null!;

    public DateTime ReturnDate { get; set; }

    public int? ElapsedDate { get; set; }

    public int? RFine { get; set; }

    public int? CarId { get; set; }

    public int? InspectorId { get; set; }

    public int? DriverId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Inspector? Inspector { get; set; }
}
