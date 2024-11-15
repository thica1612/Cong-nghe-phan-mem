using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class TransactionHistory
{
    public int TransactionId { get; set; }

    public Guid CustomerId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public string? TransactionType { get; set; }

    public decimal? Amount { get; set; }

    public virtual KoiUser Customer { get; set; } = null!;
}
