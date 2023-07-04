using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;
using LoginDBRepo.Repositories;
using LoginDBServices.Interfaces;
using LoginDBServices.Models.DTOs;
using LoginDBServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LoginDBContext>();

// Services Business Logic Layer

// Services to Create a Rol
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IModuleRolRepository, ModuleRolRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();

// To get all the modules related to a specified user
builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<IValidateTokenService, ValidateTokenService>();


// To manage Login Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountRolRepository, AccountRolRepository>();
builder.Services.AddScoped<IGenerateWebTokenService, GenerateWebTokenService>();
// Auth Conf
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtIssuer"],
        ValidAudience = builder.Configuration["JwtAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"])),
        ClockSkew = TimeSpan.Zero // remove delay of token when expire
    };
});
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.Use(async (context, next) =>
{
    var userData = context.Request.Cookies["UserData"];

    if (!string.IsNullOrEmpty(userData))
    {
        var userDataJson = JsonConvert.DeserializeObject<UserResponse>(userData);
        context.Request.Headers.Add($"Authorization", $"Bearer {userDataJson.Token}");
    }
    await next();
});

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "navbar",
        pattern: "Navbar",
        defaults: new { controller = "Navbar", action = "Index" }
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();