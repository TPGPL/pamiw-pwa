using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using pamiw_pwa;
using pamiw_pwa.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8081/api/") });
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IPublisherService, PublisherService>();
builder.Services.AddSingleton<IBookService, BookService>();

await builder.Build().RunAsync();