using System.Globalization;
using System.Reflection;
using AKSoftware.Localization.MultiLanguages;
using ChabadNapa;
using ChabadNapa.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<StateService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddLanguageContainer(Assembly.GetExecutingAssembly(), CultureInfo.GetCultureInfo("he-IL"));

await builder.Build().RunAsync();