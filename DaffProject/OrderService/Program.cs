using Microsoft.EntityFrameworkCore;
using OrderService.DAL;
using OrderService.Domain;
using OrderService.Repository;
using OrderService.Service;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<DaffECommerceDbContext>();
builder.Services.AddDbContext<DaffECommerceDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnectionString"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderService<Order>, OrderService.Service.OrderService>();
builder.Services.AddScoped<IOrderRepository<Order>, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
