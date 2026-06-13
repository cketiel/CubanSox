using CubanSox.Web.Client.Pages;
using CubanSox.Web.Components;
using MudBlazor.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Configurar HttpClient para que apunte a la URL de tu API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://kn9pct61-7274.usw3.devtunnels.ms/") 
    //BaseAddress = new Uri("https://localhost:7274/") 
});

// Registrar servicios de MudBlazor
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Comente la redirección HTTPS para que me funcionara Tor
//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CubanSox.Web.Client._Imports).Assembly);

// Configurar Cultura Española / Cubana
var cultureInfo = new CultureInfo("es-CU"); // o "es-ES"
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.Run();
