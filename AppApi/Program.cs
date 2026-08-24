using BAL.Services;
using BLL;
using DAL.EF;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FoodmanagmentsystemContext>(opt =>
{
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DbConn")
    );
});

builder.Services.AddScoped<RestaurantRepo>();
builder.Services.AddScoped<RestaurantService>();

builder.Services.AddScoped<EmployeeRepo>();
builder.Services.AddScoped<EmployeeService>();


builder.Services.AddScoped<CollectionRequestRepo>();
builder.Services.AddScoped<CollectionRequestService>();


//builder.Services.AddScoped<colle>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
