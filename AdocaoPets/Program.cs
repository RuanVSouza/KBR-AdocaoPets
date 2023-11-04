using AdocaoPets.Data;
using AdocaoPets.Models;
using AdocaoPets.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionStringAdocaoPet = builder.Configuration.GetConnectionString("AdocaoPetsContext");

builder.Services.AddDbContext<AdocaoPetsContext>
    (options => options.UseMySql(connectionStringAdocaoPet, ServerVersion.Parse("8.0.25-mysql")));


builder.Services.AddScoped<AnimalService>();
builder.Services.AddScoped<PovoandoService>();
builder.Services.AddScoped<SolicitanteService>();
builder.Services.AddScoped<AdminService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Services.CreateScope().ServiceProvider.GetRequiredService<PovoandoService>().Povoar();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();