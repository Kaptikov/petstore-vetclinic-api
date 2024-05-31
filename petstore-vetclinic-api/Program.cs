using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using petstore_vetclinic_api.Data;
using petstore_vetclinic_api.Services.Animals;
using petstore_vetclinic_api.Services.ApplicationService;
using petstore_vetclinic_api.Services.CartItemService;
using petstore_vetclinic_api.Services.CartService;
using petstore_vetclinic_api.Services.CategoryService;
using petstore_vetclinic_api.Services.FavouriteItemService;
using petstore_vetclinic_api.Services.FavouriteService;
using petstore_vetclinic_api.Services.OrderService;
using petstore_vetclinic_api.Services.ProductImgService;
using petstore_vetclinic_api.Services.ProductService;
using petstore_vetclinic_api.Services.SubcategoryService;
using petstore_vetclinic_api.Services.UserService;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImgService, ProductImgService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();
builder.Services.AddScoped<IFavouriteItemService, FavouriteItemService>();
//builder.Services.AddScoped<IFavouriteService, FavouriteService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();    

app.UseAuthorization();

app.MapControllers();

app.Run();
