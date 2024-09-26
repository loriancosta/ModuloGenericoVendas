using Microsoft.EntityFrameworkCore;
using Serilog;
using Vendas.Application.Services.Implementations;
using Vendas.Application.Services.Interfaces;
using Vendas.Data.Context;
using Vendas.Data.Repositories.Implementations;
using Vendas.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurações do AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Serilog
builder.Host.UseSerilog((context, config) =>
{
    config
        .WriteTo.Console()
        .WriteTo.File("Logs/vendas-log-.txt", rollingInterval: RollingInterval.Day)
        .Enrich.FromLogContext();
});


builder.Services.AddControllers();

builder.Services.AddScoped<IVendaEventService, VendaEventService>();
builder.Services.AddScoped<IItemVendaEventService, ItemVendaEventService>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IItemVendaService, ItemVendaService>();

builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IItemVendaRepository, ItemVendaRepository>();

builder.Services.AddDbContext<VendasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vendas API v1.0");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
