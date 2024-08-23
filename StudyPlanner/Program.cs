using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudyPlanner.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite($"Data Source={nameof(ApplicationDbContext.ApplicationDatabase)}.db");
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication();

// builder.Services.AddAuthentication(options =>
//     {
//         options.DefaultScheme = IdentityConstants.ApplicationScheme;
//         options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//         options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//     }).AddGoogle(googleOptions =>
//     {
//         googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//         googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//         googleOptions.CallbackPath = "/sign-oidc";
//
//     })
//     .AddMicrosoftAccount(microsoftOptions =>
//     {
//         microsoftOptions.ClientId = "6fa1f6e3-8571-45aa-bd39-771cc546800e"; // Application (client) ID
//         microsoftOptions.ClientSecret = builder.Configuration["Microsoft:Secret"];
//         microsoftOptions.CallbackPath = "/signin-oidc";
//         microsoftOptions.Scope.Add("openid offline_access");
//     
//     }).AddIdentityCookies();
//



builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

app.UseFastEndpoints().UseSwaggerGen();

app.UseHttpsRedirection();

app.Run();