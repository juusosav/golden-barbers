using GoldenBarbers.Client;
using GoldenBarbers.Client.Helpers;
using GoldenBarbers.Client.Pages;
using GoldenBarbers.Client.Services.Admin;
using GoldenBarbers.Client.Services.Public;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Core
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Domain services

// Public
builder.Services.AddScoped<BarberApiService>();
builder.Services.AddScoped<OfferingApiService>();
builder.Services.AddScoped<TimeslotApiService>();
builder.Services.AddScoped<AppointmentApiService>();
builder.Services.AddScoped<ScrollService>();

// Admin
builder.Services.AddScoped<AdminDashboardApiService>();
builder.Services.AddScoped<AdminAppointmentApiService>();
builder.Services.AddScoped<AdminBarberApiService>();
builder.Services.AddScoped<AdminOfferingApiService>();
builder.Services.AddScoped<AdminMetricApiService>();

// UI helpers
builder.Services.AddScoped<CarouselApiService>();

await builder.Build().RunAsync();
