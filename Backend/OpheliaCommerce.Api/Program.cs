using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpheliaCommerce.App.Mapper;
using OpheliaCommerce.App.Services;
using OpheliaCommerce.App.Validators;
using OpheliaCommerce.Data.Context;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var MyOrigin = "MyOrigin";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EcommerceContext>(options => 
{
    options.UseSqlServer(configuration.GetConnectionString("Db"));
});
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IShoppingService, ShoppingService>();
builder.Services.AddTransient<IValidator, Validator>();
builder.Services.AddAutoMapper(typeof(Program));

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new MapperProfiles());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyOrigin,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200/").AllowAnyOrigin().AllowAnyHeader();
                          builder.AllowAnyMethod().AllowAnyHeader();
                      });
});

var app = builder.Build();
app.UseCors(MyOrigin);
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
