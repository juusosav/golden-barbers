using GoldenBarbers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GoldenBarbers.Services.Admin;
using GoldenBarbers.Services.Public;
using GoldenBarbers.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Public services
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<PricingService>();
builder.Services.AddScoped<BarberService>();
builder.Services.AddScoped<CarouselService>();
builder.Services.AddScoped<OfferingService>();

// Admin services
builder.Services.AddScoped<AdminDashboardService>();
builder.Services.AddScoped<AdminBarberService>();
builder.Services.AddScoped<AdminAppointmentService>();
builder.Services.AddScoped<AdminOfferingService>();
builder.Services.AddScoped<AdminMetricService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient",
        policy => policy
            .WithOrigins(builder.Configuration["AllowedOrigins"]!)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };

    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

var app = builder.Build();

await app.SeedAdminUserAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseCors("AllowClient");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.MapFallbackToFile("/{**path:nonfile}", "index.html");

app.Run();
