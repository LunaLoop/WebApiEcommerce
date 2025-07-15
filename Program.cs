using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Data;
using WebApiEcommerce.RN;
using WebApiEcommerce.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TiendaVirtualContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<ZonaRN>();
builder.Services.AddScoped<CategoriaRN>();
builder.Services.AddScoped<ProductoRN>();
builder.Services.AddSingleton<CloudinaryService>();
builder.Services.AddScoped<ImagenService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
