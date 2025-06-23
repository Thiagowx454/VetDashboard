using Microsoft.EntityFrameworkCore;
using VetDashboard.Models.Entities; // <-- CORRIGIDO: Apontando para a pasta correta
using VetDashboard.Services;       // <-- Adicionado para o servi�o do dashboard

var builder = WebApplication.CreateBuilder(args);

// Adicionando servi�os ao container.

// 1. Configurando o DbContext para usar o SQL Server com a sua Connection String
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registrando seu servi�o de dashboard (mesmo que esteja vazio/comentado por enquanto)
builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Rota padr�o apontando para o DashboardController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();