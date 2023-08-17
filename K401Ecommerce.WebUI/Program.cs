using AutoMapper;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Business.AutoMapper;
using K401Ecommerce.Business.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.DataAccess.Abstract.DataSeeding;
using K401Ecommerce.DataAccess.Concrete.DataSeeding;
using K401Ecommerce.DataAccess.Concrete.EntityFramework;
using K401Ecommerce.DataAccess.Concrete.SqlLite;
using K401Ecommerce.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using K401Ecommerce.Business.DependencyResolver.DependencyRegister;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Reflection;
using K401Ecommerce.WebUI.Helpers.LanguageSettings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.


builder.Services.AddSingleton<LanguageService>();


builder.Services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(ShareResource).GetTypeInfo().Assembly.FullName);

                        return factory.Create("ShareResource", assemblyName.Name);
                    };
                });

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.Configure<RequestLocalizationOptions>(
                options => {
                    var supportedCultures = new List<CultureInfo>

                    {
                        new CultureInfo("az"),
                        new CultureInfo("en-US"),
                        new CultureInfo("ru-RU")
                    };


                    options.DefaultRequestCulture = new RequestCulture(culture: "az", uiCulture: "az");

                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
                });



builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();



builder.Services.AddControllersWithViews();


builder.Services.Create();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
endpoint.MapControllerRoute(
     name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}/{seourl?}"
   );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{seourl?}");

app.Run();

