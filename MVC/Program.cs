using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;

builder.Services.AddTransient<IStockTypeDal, EfCoreStockType>();
builder.Services.AddTransient<IStockTypeService, StockTypeManager>();

builder.Services.AddTransient<IStockUnitDal, EfCoreStockUnitDal>();
builder.Services.AddTransient<IStockUnitService, StockUnitManager>();

builder.Services.AddTransient<IStockDal, EfCoreStockDal>();
builder.Services.AddTransient<IStockService, StockManager>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
