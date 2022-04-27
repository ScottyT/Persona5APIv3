using Microsoft.EntityFrameworkCore;
using Persona5APIv3;
using Persona5APIv3.Interface;
using Persona5APIv3.Models;
using Persona5APIv3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PersonaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PersonaContext")));
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddHostedService(sp => new NpmWatchHostedService(
    enabled: sp.GetRequiredService<IWebHostEnvironment>().IsDevelopment(),
    logger: sp.GetRequiredService<ILogger<NpmWatchHostedService>>()
));
builder.Services.AddWebOptimizer(pipeline =>
        {
            /* pipeline.AddCssBundle("/wwwroot/css/bundle.css", "/wwwroot/css/site.css", "/wwwroot/lib/bootstrap/css/bootstrap.css");
            pipeline.AddJavaScriptBundle("/wwwroot/js/bundle.js", "/wwwroot/js/persona.main.js","/wwwroot/lib/bootstrap/js/bootstrap.js"); */
            pipeline.MinifyCssFiles();
            pipeline.MinifyJsFiles();
        });
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseWebOptimizer();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
