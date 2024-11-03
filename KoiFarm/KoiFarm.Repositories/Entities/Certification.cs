using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class Certification
{
    public string CertificationId { get; set; } = null!;

    public string KoiId { get; set; } = null!;

    public string? OriginCertificate { get; set; }

    public string? HealthCertificate { get; set; }

    public DateOnly? CertificationDate { get; set; }

    public virtual Koi Koi { get; set; } = null!;
}
