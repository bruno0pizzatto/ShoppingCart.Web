using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShoppingCart.Web;
using ShoppingCart.Web.Services;
using ShoppingCart.Web.Services.Contratcs;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7050/") });
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
