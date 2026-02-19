using GoldenBarbers.Client;
using GoldenBarbers.Client.Pages;
using GoldenBarbers.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthStateProvider>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<BarberService>();
builder.Services.AddScoped<CarouselService>();
builder.Services.AddScoped<OfferingService>();
builder.Services.AddScoped<TimeslotService>();
builder.Services.AddScoped<AppointmentsService>();

await builder.Build().RunAsync();
