using BugStore.Data;
using BugStore.Endpoints.Customer;
using BugStore.Endpoints.Order;
using BugStore.Endpoints.Product;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite(connectionString));

builder.Services.AddScoped<BugStore.Handlers.Customers.ICustomerHandler, BugStore.Handlers.Customers.Handler>();
builder.Services.AddScoped<BugStore.Handlers.Order.IOrderHandle, BugStore.Handlers.Order.Handler>();
builder.Services.AddScoped<BugStore.Handlers.Product.IProductHandle, BugStore.Handlers.Product.Handler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.MapCustomerEndpoints();
app.MapOrderEndpoints();
app.MapProductEndpoints();

app.Run();