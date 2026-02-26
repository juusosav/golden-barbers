using GoldenBarbers.Client;
using GoldenBarbers.Client.Pages;
using GoldenBarbers.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Core
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthStateProvider>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Http
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Domain services
builder.Services.AddScoped<BarberService>();
builder.Services.AddScoped<OfferingService>();
builder.Services.AddScoped<TimeslotService>();
builder.Services.AddScoped<AppointmentsService>();

// UI helpers
builder.Services.AddScoped<CarouselService>();

await builder.Build().RunAsync();
