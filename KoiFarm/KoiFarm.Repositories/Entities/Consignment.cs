using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class Consignment
{
    public int ConsignmentId { get; set; }

    public string? ConsignmentType { get; set; }

    public DateOnly? RequestDate { get; set; }

    public decimal? AgreedPrice { get; set; }

    public string? ConsignmentStatus { get; set; }
}
