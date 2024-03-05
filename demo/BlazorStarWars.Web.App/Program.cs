using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorStarWars.Web.App;
using BlazorStarWars.Web.App.Ratings;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddStarWarsClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://swapi-graphql.netlify.app/.netlify/functions/index"));

builder.Services
    .AddRatingClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7221/graphql"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
