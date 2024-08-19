using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.BusinessLogicLayer.Abstract;
using MultiShop.Cargo.BusinessLogicLayer.Concrete;
using MultiSop.Cargo.DataAccessLayer.Abstracts.Inferfaces;
using MultiSop.Cargo.DataAccessLayer.Concrete;
using MultiSop.Cargo.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.Audience = "ResourceCargo";
    option.Authority = builder.Configuration["IdentityServerUrl"];
    option.RequireHttpsMetadata = false;

});

builder.Services.AddDbContext<CargoDbContext>();

builder.Services.AddScoped<ICargoCompanyService,CargoCompanyManager>();
builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompany>();

builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomer>();
builder.Services.AddScoped<ICargoCustomerService,CargoCustomerManager>();

builder.Services.AddScoped<ICargoDetailDal, EfCargoDetail>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();

builder.Services.AddScoped<ICargoOperationsDal, EfCargoOperations>();
builder.Services.AddScoped<ICargoOperationService,CargoOperationManager>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
