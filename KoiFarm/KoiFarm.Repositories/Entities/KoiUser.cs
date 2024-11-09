using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class KoiUser
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? UserPassword { get; set; }

    public string? Phonenumber { get; set; }

    public string? UserRole { get; set; }

    public string? UserAddress { get; set; }

    public decimal? PointBalance { get; set; }

    public DateOnly? DateJoined { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<KoiOrder> KoiOrders { get; set; } = new List<KoiOrder>();

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
