using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using StudyPlanner.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite($"Data Source={nameof(ApplicationDbContext.ApplicationDatabase)}.db");
});

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
builder.Services.AddAuthentication().AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

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

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultExceptionHandler();
app.UseFastEndpoints().UseSwaggerGen();

app.Run();