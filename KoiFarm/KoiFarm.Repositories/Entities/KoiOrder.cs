using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class KoiOrder
{
    public int OrderId { get; set; }

    public string CustomerId { get; set; } = null!;

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public virtual KoiUser Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
