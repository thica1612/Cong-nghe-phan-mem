using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFarm.Repositories.Entities;

public partial class KoiFarmContext : DbContext
{
    public KoiFarmContext()
    {
    }

    public KoiFarmContext(DbContextOptions<KoiFarmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<CertificationKoiSale> CertificationKoiSales { get; set; }

    public virtual DbSet<Consignment> Consignments { get; set; }

    public virtual DbSet<DashboardDatum> DashboardData { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Koi> Kois { get; set; }

    public virtual DbSet<KoiOrder> KoiOrders { get; set; }

    public virtual DbSet<KoiSale> KoiSales { get; set; }

    public virtual DbSet<KoiUser> KoiUsers { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-FOMTFDFM\\SQLEXPRESS;Initial Catalog=KoiFarm;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.CertificationId).HasName("PK__Certific__1237E5AA657315C4");

            entity.ToTable("Certification");

            entity.Property(e => e.CertificationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CertificationID");
            entity.Property(e => e.HealthCertificate)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.KoiId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("KoiID");
            entity.Property(e => e.OriginCertificate)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Koi).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__KoiID__3D5E1FD2");
        });

        modelBuilder.Entity<CertificationKoiSale>(entity =>
        {
            entity.HasKey(e => e.CertificationKsid).HasName("PK__Certific__5192CFD648610E09");

            entity.ToTable("CertificationKoiSale");

            entity.Property(e => e.CertificationKsid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CertificationKSID");
            entity.Property(e => e.CertificationDateKs).HasColumnName("CertificationDateKS");
            entity.Property(e => e.HealthCertificateKs)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HealthCertificateKS");
            entity.Property(e => e.KoiSaleId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("KoiSaleID");
            entity.Property(e => e.OriginCertificateKs)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OriginCertificateKS");

            entity.HasOne(d => d.KoiSale).WithMany(p => p.CertificationKoiSales)
                .HasForeignKey(d => d.KoiSaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__KoiSa__403A8C7D");
        });

        modelBuilder.Entity<Consignment>(entity =>
        {
            entity.HasKey(e => e.ConsignmentId).HasName("PK__Consignm__2AB758636F5F72E9");

            entity.ToTable("Consignment");

            entity.Property(e => e.ConsignmentId)
                .ValueGeneratedNever()
                .HasColumnName("ConsignmentID");
            entity.Property(e => e.AgreedPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ConsignmentStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConsignmentType)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DashboardDatum>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Dashboar__D5BD48E5505ED8FD");

            entity.Property(e => e.ReportId)
                .ValueGeneratedNever()
                .HasColumnName("ReportID");
            entity.Property(e => e.MetricName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MetricValue).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF65F3E19C6");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("FeedbackID");
            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.KoiId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("KoiID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Custom__4CA06362");

            entity.HasOne(d => d.Koi).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__KoiID__4D94879B");
        });

        modelBuilder.Entity<Koi>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__Koi__915924EF1FC19E01");

            entity.ToTable("Koi");

            entity.Property(e => e.KoiId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("koiID");
            entity.Property(e => e.Dailyfood)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("dailyfood");
            entity.Property(e => e.KoiGender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("koiGender");
            entity.Property(e => e.KoiImage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("koiImage");
            entity.Property(e => e.KoiName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("koiName");
            entity.Property(e => e.KoiOrigin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("koiOrigin");
            entity.Property(e => e.KoiPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("koiPrice");
            entity.Property(e => e.KoiSize).HasColumnName("koiSize");
            entity.Property(e => e.KoiYear).HasColumnName("koiYear");
            entity.Property(e => e.Screeningrate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("screeningrate");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<KoiOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__KoiOrder__C3905BAFEA99FA68");

            entity.ToTable("KoiOrder");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.KoiOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KoiOrder__Custom__4316F928");
        });

        modelBuilder.Entity<KoiSale>(entity =>
        {
            entity.HasKey(e => e.KoiSaleId).HasName("PK__KoiSale__D586FFEB7D202805");

            entity.ToTable("KoiSale");

            entity.Property(e => e.KoiSaleId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("koiSaleID");
            entity.Property(e => e.DailyfoodKoiSale)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("dailyfoodKoiSale");
            entity.Property(e => e.DiscountPercent)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discountPercent");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.KoiImageKoiSale)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("koiImageKoiSale");
            entity.Property(e => e.KoiSaleGender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("koiSaleGender");
            entity.Property(e => e.KoiSaleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("koiSaleName");
            entity.Property(e => e.KoiSaleOrigin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("koiSaleOrigin");
            entity.Property(e => e.KoiSalePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("koiSalePrice");
            entity.Property(e => e.KoiSalePriceLater)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("koiSalePriceLater");
            entity.Property(e => e.KoiSaleSize).HasColumnName("koiSaleSize");
            entity.Property(e => e.KoiSaleYear).HasColumnName("koiSaleYear");
            entity.Property(e => e.ScreeningrateKoiSale)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("screeningrateKoiSale");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.StockKoiSale).HasColumnName("stockKoiSale");
        });

        modelBuilder.Entity<KoiUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__KoiUser__CB9A1CDFED6BE4FA");

            entity.ToTable("KoiUser");

            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("userID");
            entity.Property(e => e.DateJoined).HasColumnName("dateJoined");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phonenumber");
            entity.Property(e => e.PointBalance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("pointBalance");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("userAddress");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userName");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userPassword");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userRole");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C432669B4");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.KoiId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("KoiID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Koi).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__KoiID__46E78A0C");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__45F365D3");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__52C42F2FF45A9CF3");

            entity.ToTable("Promotion");

            entity.Property(e => e.PromotionId)
                .ValueGeneratedNever()
                .HasColumnName("PromotionID");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PromotionName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B25D88C0D");

            entity.ToTable("TransactionHistory");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("TransactionID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Custo__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
