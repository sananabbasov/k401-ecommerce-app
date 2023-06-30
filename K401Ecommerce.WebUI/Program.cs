using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Business.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.DataAccess.Concrete.EntityFramework;
using K401Ecommerce.DataAccess.Concrete.SqlLite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

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

