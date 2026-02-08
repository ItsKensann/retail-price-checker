using retailpricechecker.Components;
using retailpricechecker.Services;
using retailpricechecker.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var config = builder.Configuration;

builder.Services.AddSingleton<LocationState>();

builder.Services.AddHttpClient<IRetailProdClientService, RetailProdClientService>((client) =>
{
    client.BaseAddress = new Uri(config["RetailProdServiceBaseUrl"]!, UriKind.Absolute);
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config["Secrets-resteam-APIGateway-SupplyChainServiceKey"]);
});

builder.Services.AddHttpClient<ILocationClientService, LocationClientService>((client) =>
{
    client.BaseAddress = new Uri(config["LocationServiceBaseUrl"]!, UriKind.Absolute);
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config["Secrets-resteam-APIGateway-SupplyChainServiceKey"]);
});

builder.Services.AddHttpClient<ICommercePricingClientService, CommercePricingClientService>((client) =>
{
    client.BaseAddress = new Uri(config["CommercePricingServiceBaseUrl"]!, UriKind.Absolute);
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config["Secrets-resteam-APIGateway-CommerceServiceKey"]);
});

builder.Services.AddHttpClient<IImageService, ImageService>((client) =>
{
    client.BaseAddress = new Uri(config["ImageServiceBaseUrl"]!, UriKind.Absolute);
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config["Secrets-resteam-APIGateway-CommerceServiceKey"]);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
