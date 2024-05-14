using ISEnglish.DataAccess;
using ISEnglish.DataAccess.Repositories;
using ISEnglish.Domain.Interfaces.Auth;
using ISEnglish.Domain.Interfaces.Repositories;
using ISEnglish.Infrastructure;
using ISEnglish.Services.BL;
using ISEnglishMVC.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ISEnglishDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ISEnglishDbContext)));
    });

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddScoped<IWordsService, WordsService>();
builder.Services.AddScoped<IWordsRepository, WordsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<JwtOptions>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserService, UserService>();

var provider = builder.Services.BuildServiceProvider();
var configurations = provider.GetRequiredService<IConfiguration>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireClaim("Admin", "true");
    });
    options.AddPolicy("StudentPolicy", policy =>
    {
        policy.RequireClaim("Student", "true");
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kursovayakursovayakursovayakursovayakursovayakursovaya"))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["ts-cookies"];
                            return Task.CompletedTask;
                        }
                    };
                });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseCookiePolicy(new CookiePolicyOptions
//{
//    MinimumSameSitePolicy = SameSiteMode.Strict,
//    HttpOnly = HttpOnlyPolicy.Always,
//    Secure = CookieSecurePolicy.Always
//});

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
