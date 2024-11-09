using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services;
using KoiFarm.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//DI 
builder.Services.AddDbContext<KoiFarmContext>();
//DI Repository
builder.Services.AddScoped<IKoiUserRepository, KoiUserRepository>();
//DI Services
builder.Services.AddScoped<IKoiUserService, KoiUserService>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
