using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using pamiw_pwa;
using pamiw_pwa.Security;
using pamiw_pwa.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<String>("BaseAPIUrl")) });
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IPublisherService, PublisherService>();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<ITokenService, TokenService>();


builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<JwtAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore(conf =>
{
    conf.AddPolicy(Policies.IsUserLog, Policies.IsUserLogged());
});
builder.Services.AddSingleton<AuthState>();

await builder.Build().RunAsync();