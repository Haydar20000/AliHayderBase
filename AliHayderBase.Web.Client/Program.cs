using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AliHayderBase.Shared.Services;
using AliHayderBase.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the AliHayderBase.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
