using CoffeeTime.Core.Repositories;
using CoffeeTime.Core.Services;
using CoffeeTime.Data;
using CoffeeTime.Data.Repositories;
using CoffeeTime.Service;
using CoffeeTime.API.Controllers;
using CoffeeTime.API.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoffeeTime.Core.Mapping;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens.Experimental;
using Microsoft.IdentityModel.Tokens;
//using AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//הוספתי בשעור 13
Console.WriteLine(builder.Configuration["Connection_String"]);
//???builder.Configuration["Connection_String"];
//builder.Services.AddSingleton<DataContext>();
//builder.Services.AddScoped<IConfiguration,>();//?לבדוק???????????????????/
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();


builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductService, ProductsService>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();

//זה לא עבד

//builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



////גמיני אמר את זה אבל אז נהיה עוד שגיאות נמאס לי
//builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

builder.Services.AddDbContext<DataContext>();
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddScoped<JwtService> ();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//הוספנו לאימות בגלל ג'וט
app.UseAuthentication ();

app.UseAuthorization();

app.UseMiddleware<UserMiddleware>();
app.MapControllers();

app.Run();
