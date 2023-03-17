using Arch_lab.Models;
using Arch_lab.Models.DAL;
using Arch_lab.Models.DAL.Interfaces;
using Arch_lab.Models.DAL.Repositories;
using Arch_lab.Services.Implementations;
using Arch_lab.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IBaseRepository<Email>, EmailRepository>();
builder.Services.AddScoped<IBaseRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IBaseRepository<Certificate>, CertificateRepository>();
builder.Services.AddScoped<IBaseRepository<PublicKey>, PublicKeyRepository>();
builder.Services.AddScoped<IBaseRepository<PrivateKey>, PrivateKeyRepository>();


builder.Services.AddScoped<IEmailService, EmailService>(); 
builder.Services.AddScoped<IAccountService, AccountService>(); 
builder.Services.AddScoped<ICryptoService, CryptoService>(); 


var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/Account/Login");
    options.AccessDeniedPath = new PathString("/Account/Login");
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
