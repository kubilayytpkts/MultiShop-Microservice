using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailsHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.Authority = builder.Configuration["IdentityServerUrl"];
    option.Audience = "ResourceOrder";
    option.RequireHttpsMetadata = false;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<OrderDbContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAplicationService(builder.Configuration);


builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();

builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();

builder.Services.AddScoped<CreateOrderingHandler>();
builder.Services.AddScoped<UpdateOrderingHandler>();
builder.Services.AddScoped<DeleteOrderingHandler>();
builder.Services.AddScoped<GetOrderingByIdHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
