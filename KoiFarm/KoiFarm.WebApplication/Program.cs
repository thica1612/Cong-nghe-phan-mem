using FluentAssertions.Common;
using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services;
using KoiFarm.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//DI 
builder.Services.AddDbContext<KoiFarmContext>(options=>
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

//builder.Services.AddScoped<IOrderService, OrderDetailService>();
// Đăng ký Repository cho Order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
