using Blazored.Toast;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using PersonalBlogSystem.BlazorUI;
using PersonalBlogSystem.BlazorUI.Constants;
using PersonalBlogSystem.BlazorUI.Services.Concrete;
using PersonalBlogSystem.BlazorUI.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(ApiConstants.ApiUrl) });
builder.Services.AddScoped<IHttpBlogService, HttpBlogService>();
builder.Services.AddScoped<IHttpCategoryService, HttpCategoryService>();
builder.Services.AddScoped<IHttpContentService, HttpContentService>();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
