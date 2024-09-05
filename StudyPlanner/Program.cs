using FastEndpoints;
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

// Default Identity Api Endpoints only .NET 8+
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


// WRONG SCHEMA CHOSEN DO NOT ADD AddAuthentication any default schema
// Because default local sign in uses Cookies transform to tokens BUT not to JWT tokens :)
builder.Services.AddAuthentication().AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var claims = context.User.Claims;
            return claims.Any(c =>
                c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" && c.Value == "Admin");
        });
    });
});
// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("LecturerPolicy", policy => policy.RequireRole("Lecturer"));
// });


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


app.MapGroup("/auth").MapIdentityApi<ApplicationUser>();

app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultExceptionHandler();
app.UseFastEndpoints().UseSwaggerGen();

app.Run();