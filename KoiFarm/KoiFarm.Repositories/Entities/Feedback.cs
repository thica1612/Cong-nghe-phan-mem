using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public Guid CustomerId { get; set; }

    public string KoiId { get; set; } = null!;

    public int? Rating { get; set; }

    public string? Comments { get; set; }

    public DateOnly? FeedbackDate { get; set; }

    public virtual KoiUser Customer { get; set; } = null!;

    public virtual Koi Koi { get; set; } = null!;
}
