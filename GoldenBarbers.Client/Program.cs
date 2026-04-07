using GoldenBarbers.Client;
using GoldenBarbers.Client.Helpers;
using GoldenBarbers.Client.Services.Admin;
using GoldenBarbers.Client.Services.Public;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddLocalization();

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

// Admin
builder.Services.AddScoped<AdminDashboardApiService>();
builder.Services.AddScoped<AdminAppointmentApiService>();
builder.Services.AddScoped<AdminBarberApiService>();
builder.Services.AddScoped<AdminOfferingApiService>();
builder.Services.AddScoped<AdminMetricApiService>();

// UI helpers
builder.Services.AddScoped<CarouselApiService>();
builder.Services.AddScoped<ScrollService>();

var host = builder.Build();

var js = host.Services.GetRequiredService<IJSRuntime>();

var storedCulture = await js.InvokeAsync<string>(
    "cultureManager.get"
    );

CultureInfo culture;

// If localStorage contains garbage
try
{
    const string defaultCulture = "en-US";

    culture = !string.IsNullOrWhiteSpace(storedCulture)
        ? new CultureInfo(storedCulture)
        : new CultureInfo(defaultCulture);
}

catch (CultureNotFoundException)
{
    culture = new CultureInfo("en-US");
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
