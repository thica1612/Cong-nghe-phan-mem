using System;
using System.Collections.Generic;

namespace KoiFarm.Repositories.Entities;

public partial class KoiSale
{
    public string KoiSaleId { get; set; } = null!;

    public string? KoiSaleName { get; set; }

    public string? KoiSaleOrigin { get; set; }

    public string? KoiSaleGender { get; set; }

    public int? KoiSaleYear { get; set; }

    public int? KoiSaleSize { get; set; }

    public decimal? KoiSalePrice { get; set; }

    public decimal? KoiSalePriceLater { get; set; }

    public decimal? DiscountPercent { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? Enddate { get; set; }

    public int? StockKoiSale { get; set; }

    public string? KoiImageKoiSale { get; set; }

    public decimal? DailyfoodKoiSale { get; set; }

    public decimal? ScreeningrateKoiSale { get; set; }

    public virtual ICollection<CertificationKoiSale> CertificationKoiSales { get; set; } = new List<CertificationKoiSale>();
}
