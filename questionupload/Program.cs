using Microsoft.EntityFrameworkCore;
using questionupload.Data;
using questionupload.Data.Repository.impl;
using questionupload.Data.Repository;
using questionupload.Services;
using questionupload.Services.impl;
using questionupload.Services.utils;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>((options) =>
{


    options.UseSqlServer("data source =Persist Security Info=False;User ID=Arijit;Password=Arijit@05;Initial Catalog=questionUpload;Server=DESKTOP-FRSO5JF\\SQLEXPRESS;TrustServerCertificate=true;");



});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = null,
                       ValidAudience = null,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key")))
                   };
               });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAccessibilityService, AccessibilityService>();
builder.Services.AddScoped<IAccessibilityRepository, AccessibilityRepository>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireRole("admin");
        policy.RequireClaim("Permission", ["all"]);
 
    });
});
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
