using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class CertificationKoiSale
{
    public string CertificationKsid { get; set; } = null!;

    public string KoiSaleId { get; set; } = null!;

    public string? OriginCertificateKs { get; set; }

    public string? HealthCertificateKs { get; set; }

    public DateOnly? CertificationDateKs { get; set; }

    public virtual KoiSale KoiSale { get; set; } = null!;
}
