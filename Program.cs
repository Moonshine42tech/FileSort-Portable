using ElectronNET.API;
using ElectronNET.API.Entities;

var builder = WebApplication.CreateBuilder(args);

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
      //Title = "FileSort",
      Height = 525,
      MaxHeight = 525,
      MinHeight= 525,
      Width = 410,
      MaxWidth = 410,
      MinWidth = 410,
      Center = true,
      Fullscreenable = false
    };

    // Making the electron window
    var window = await Electron.WindowManager.CreateWindowAsync(options);

    // Startup path (for fun)
    //window.LoadURL("https://www.google.com");

    // On close the single window
    window.OnClosed += () => {
        Electron.App.Quit();
    };
}

