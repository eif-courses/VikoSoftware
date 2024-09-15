using System.Text;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using StudyPlanner.Data;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (!builder.Environment.IsDevelopment())
{
    connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
}

builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(connectionString); });


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders(); // Optional, if you still need token providers for things like email confirmation


// LOCAL AUTHENTICATION FAST ENDPOINTS SECURITY PACKAGE
// COokie test dev only disable cross domains SameSite
//         options.Cookie.SecurePolicy = CookieSecurePolicy.None; ALSO NEED CHANGE
builder.Services.AddAuthenticationCookie(validFor: TimeSpan.FromMinutes(30),
    options =>
    {
        options.LoginPath = "/auth/mfa/signin";
        options.LogoutPath = "/auth/mfa/signout";
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        // options.SameSite = SameSiteMode.None,
        // Secure = true,
    });

// MICROSOFT AUTHENTICATION
builder.Services.AddAuthentication()
    .AddJwtBearer("LocalJwtBearer", options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Authentication:Jwt");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
            ValidateIssuer = false,//jwtSettings["Authority"].ToString(),
            ValidateAudience = false,//jwtSettings["Audience"],
        };
    })
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

// Call the method to seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedData.Initialize(userManager, roleManager);
}


app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultExceptionHandler();
app.UseFastEndpoints().UseSwaggerGen();

app.Run();


// FREE DB POSTGRES : https://cloud.tembo.io/