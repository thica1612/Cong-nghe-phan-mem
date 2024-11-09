using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class Koi
{
    public string KoiId { get; set; } = null!;

    public string? KoiName { get; set; }

    public string? KoiOrigin { get; set; }

    public string? KoiGender { get; set; }

    public int? KoiYear { get; set; }

    public int? KoiSize { get; set; }

    public decimal? KoiPrice { get; set; }

    public int? Stock { get; set; }

    public string? KoiImage { get; set; }

    public decimal? Dailyfood { get; set; }

    public decimal? Screeningrate { get; set; }

    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
