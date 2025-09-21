using AliHayderBase.Web.Components;
using AliHayderBase.Shared.Services;
using AliHayderBase.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AliHayderBase.Web.Persistence;
using AliHayderBase.Web.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add Services from Dependencies\ServiceCollectionExtensions
builder.Services.AddAliHayderBaseServices(builder.Configuration);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add Swagger services to the container.... Start
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Swagger services to the container.... End

builder.Services.AddControllers();

// Add device-specific services used by the AliHayderBase.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    // Add Swagger services to the container.... Start
    app.UseSwagger();
    app.UseSwaggerUI();
    // Add Swagger services to the container.... End
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(AliHayderBase.Shared._Imports).Assembly,
        typeof(AliHayderBase.Web.Client._Imports).Assembly);

app.Run();
