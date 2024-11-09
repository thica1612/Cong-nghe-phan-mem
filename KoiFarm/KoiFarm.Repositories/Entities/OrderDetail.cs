using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public string KoiId { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual Koi Koi { get; set; } = null!;

    public virtual KoiOrder Order { get; set; } = null!;
}
