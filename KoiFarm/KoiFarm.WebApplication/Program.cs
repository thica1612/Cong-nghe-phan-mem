using FluentAssertions.Common;
using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services;
using KoiFarm.Services.Interfaces;
using KoiFarm.WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

//Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddRazorPages();
//DI 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<KoiFarmContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//DI Repository
builder.Services.AddScoped<IKoiUserRepository, KoiUserRepository>();
//DI Services
builder.Services.AddScoped<IKoiUserService, KoiUserService>();

//DI Repository Certification
builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
//DI Services Certification
builder.Services.AddScoped<ICertificationService, CertificationService>();

//DI Repository CertificationKoiSale
builder.Services.AddScoped<ICertificationKoiSaleRepository, CertificationKoiSaleRepository>();
//DI Services CertificationKoiSale
builder.Services.AddScoped<ICertificationKoiSaleService, CertificationKoiSaleService>();

//DI Repository Koi
builder.Services.AddScoped<IKoiRepository, KoiRepository>();
//DI Services Koi
builder.Services.AddScoped<IKoiService, KoiService>();

//DI Repository KoiSale
builder.Services.AddScoped<IKoiSaleRepository, KoiSaleRepository>();
//DI Services KoiSale
builder.Services.AddScoped<IKoiSaleService, KoiSaleService>();

//DI Repository Feedback
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
//DI Services Feedback
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

//DI Repository Promotion
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
//DI Services Promotion
builder.Services.AddScoped<IPromotionService, PromotionService>();

builder.Services.AddScoped<ISellConsignmentRepository, SellConsignmentRepository>();
builder.Services.AddScoped<ISellConsignmentService, SellConsignmentService>();

builder.Services.AddScoped<IFeedConsignmentRepository, FeedConsignmentRepository>();
builder.Services.AddScoped<IFeedConsignmentService, FeedConsignmentService>();

//DI Repository TransactionHistory
builder.Services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
//DI Services TransactionHistory
builder.Services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//DI Repository Consignment
builder.Services.AddScoped<IConsignmentRepository, ConsignmentRepository>();
//DI Services Consignment
builder.Services.AddScoped<IConsignmentService, ConsignmentService>();


//builder.Services.AddScoped<IOrderService, OrderDetailService>();
// Đăng ký Repository cho Order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();


//DI Repository
builder.Services.AddScoped<IDashboardDataRepository, DashboardDataRepository>();
//DI Services
builder.Services.AddScoped<IDashboardDataService, DashboardDataService>();


//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<KoiFarmContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


app.UseSession();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();


