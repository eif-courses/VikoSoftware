using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudyPlanner.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite($"Data Source={nameof(ApplicationDbContext.ApplicationDatabase)}.db");
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders()
.AddApiEndpoints();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration["Microsoft:Authentication:ClientId"];
    options.ClientSecret = builder.Configuration["Microsoft:Authentication:Secret"];
    options.Authority = "https://login.microsoftonline.com/668e4f3d-c28b-450b-9ed9-a44ad99c3050/v2.0"; // Tenant ID from portal.azure.com
    options.CallbackPath = "/signin-oidc";
    options.SaveTokens = true;
    options.Scope.Add("openid");
    options.Scope.Add("offline_access");
});

builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
{
    options.LoginPath = "/auth/microsoft/login";
    options.AccessDeniedPath = "/auth/microsoft/login";
});

builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", opt =>
        opt.WithOrigins("http://localhost:3000")
           .AllowAnyHeader()
           .AllowAnyMethod());
});

builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints().UseSwaggerGen();

app.MapIdentityApi<ApplicationUser>();

app.MapGet("/auth/microsoft/login", async context =>
{
    if (!context.User.Identity.IsAuthenticated)
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = "/hello"
        };
        await context.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, properties);
    }
    else
    {
        await context.Response.WriteAsync("Already authenticated");
    }
});


app.Run();