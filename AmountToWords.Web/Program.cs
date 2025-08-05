using AmountToWords.Lib.Mapping;
using AmountToWords.Lib.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Register services with DI container
builder.Services.AddControllersWithViews();                     // MVC + Razor views
builder.Services.AddSingleton<NumberMaps>();                    // Static word mappings (safe as singleton)
builder.Services.AddScoped<IAmountToWordsConverter, AmountToWordsConverter>(); // Scoped per request, clean for web

var app = builder.Build();

// 🌐 Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    // User-friendly error page for production
    app.UseExceptionHandler("/Home/Error");

    // Enforce HTTPS with HSTS in production (defaults to 30-day cache)
    app.UseHsts(); // Consider tuning this for tighter security in long-lived APIs
}

app.UseHttpsRedirection();   // Redirect HTTP → HTTPS (a must-have)
app.UseStaticFiles();        // Serve CSS, JS, images, etc.

app.UseRouting();            // Enables endpoint routing (controllers, actions)

app.UseAuthorization();      // Placeholder for auth setup, if needed later

// 📦 Default route mapping (MVC controller pattern)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // 🚀 Kick off the application
