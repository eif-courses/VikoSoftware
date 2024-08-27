using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    .AddCookie()
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.ClientId = builder.Configuration["Microsoft:Authentication:ClientId"];
        options.ClientSecret = builder.Configuration["Microsoft:Authentication:Secret"];
        options.Authority =
            "https://login.microsoftonline.com/668e4f3d-c28b-450b-9ed9-a44ad99c3050/v2.0"; // Tenant ID from portal.azure.com
        options.CallbackPath = "/signin-oidc";
        options.Scope.Add("openid");
        options.Scope.Add("offline_access");
        options.SaveTokens = true;
        options.ClaimActions.MapJsonKey("FullName", "name");
    });

builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
{
    options.LoginPath = "/auth/microsoft";
    options.AccessDeniedPath = "/auth/microsoft";
});

builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", opt =>
        opt.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
    );
});

builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints().UseSwaggerGen();

app.MapIdentityApi<ApplicationUser>();

app.MapGet("/auth/microsoft", async (context) =>
{
    if (!context.User.Identity.IsAuthenticated)
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = "/auth/success"
        };
        await context.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, properties);
    }
    else
    {
        context.Response.Redirect("/auth/token");
    }
});

app.MapGet("/auth/success", async context =>
{
    var result = await context.AuthenticateAsync(OpenIdConnectDefaults.AuthenticationScheme);
    if (result.Succeeded)
    {
        var user = result.Principal;
        var name = user.FindFirstValue("name");
        var email = user.FindFirstValue("preferred_username");

        var userManager = context.RequestServices.GetService<UserManager<ApplicationUser>>();
        var userEntity = await userManager.FindByEmailAsync(email);

        if (userEntity == null)
        {
            userEntity = new ApplicationUser { Email = email, UserName = email, FullName = name };
            var identityResult = await userManager.CreateAsync(userEntity);
            if (!identityResult.Succeeded)
            {
                await context.Response.WriteAsJsonAsync(new { error = "Failed to create user" });
                return;
            }

            await userManager.AddToRoleAsync(userEntity, "Lecturer");
        }

        // Sign in the user
        var signInManager = context.RequestServices.GetService<SignInManager<ApplicationUser>>();
        await signInManager.SignInAsync(userEntity, isPersistent: false);

        // Redirect to a safe page or the token endpoint
        context.Response.Redirect("/auth/token");
    }
    else
    {
        await context.Response.WriteAsJsonAsync(new { error = "Authentication failed" });
    }
});

app.MapGet("/auth/token", [Authorize] async (context) =>
{
    var userManager = context.RequestServices.GetService<UserManager<ApplicationUser>>();
    var user = await userManager.GetUserAsync(context.User);

    if (user != null)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
       
        var key = Encoding.UTF8.GetBytes("N!m9^dPqW8bR7@tX5$zL3jY&Q1vK2sA#");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("email", user.Email),
                new Claim("name", user.FullName),
                new Claim("role", "Lecturer")
            }),
            Expires = DateTime.UtcNow.AddDays(14),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        context.Response.Redirect($"http://localhost:3000/auth/callback?token={tokenString}");
    }
    else
    {
        await context.Response.WriteAsJsonAsync(new { error = "User not found" });
    }
});


app.MapGet("/auth/data", async (context) =>
{
    await context.Response.WriteAsync("Hello, Lecturer!");
});

app.Run();

public class UserInfo
{
    public string Name { get; set; }

    public string Email { get; set; }
    // public List<ClaimInfo> Claims { get; set; }
}