using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class DashboardDatum
{
    public int ReportId { get; set; }

    public string? MetricName { get; set; }

    public decimal? MetricValue { get; set; }

    public DateOnly? ReportDate { get; set; }
}
