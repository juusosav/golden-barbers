using GoldenBarbers.Client;
using GoldenBarbers.Client.Pages;
using GoldenBarbers.Client.Services;
using GoldenBarbers.Client.Services.Admin;
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
builder.Services.AddScoped<AppointmentsApiService>();

// Admin
builder.Services.AddScoped<AdminDashboardApiService>();
builder.Services.AddScoped<AdminAppointmentsApiService>();
builder.Services.AddScoped<AdminBarbersApiService>();
builder.Services.AddScoped<AdminOfferingsApiService>();

// UI helpers
builder.Services.AddScoped<CarouselApiService>();

await builder.Build().RunAsync();
