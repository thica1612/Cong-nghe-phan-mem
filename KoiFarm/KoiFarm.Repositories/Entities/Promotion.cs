using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string? PromotionName { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}
