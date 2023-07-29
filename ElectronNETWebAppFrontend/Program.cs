using ElectronNET.API;
using ElectronNET.API.Entities;

var builder = WebApplication.CreateBuilder(args);

// Using Electron for the web host
builder.WebHost.UseElectron(args);
//builder.WebHost.UseEnvironment("Development");

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

if(HybridSupport.IsElectronActive) 
{
    CreateWindow();
}

app.Run();

async void CreateWindow() {

    // Browser Window option settings
    BrowserWindowOptions options = new BrowserWindowOptions() {
      //Height = 768,
      Height = 600,
      MinHeight= 600,
      //Width = 1024,
      Width = 800,
      MinWidth = 800,
      Center = true,
      Fullscreenable = false
    };

    // Making the electron window
    var window = await Electron.WindowManager.CreateWindowAsync(options);

    // On close the single window
    window.OnClosed += () => {
        Electron.App.Quit();
    };
}
