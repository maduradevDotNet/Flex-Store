using Microsoft.AspNetCore.Cors.Infrastructure;
using Store1.Web.Coupon.Service.IService;
using Store1.Web.Coupon.Service;
using Store1.Web.Coupon.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
//builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<ICouponService, CouponService>();
//builder.Services.AddHttpClient<IAuthService, AuthService>();
//builder.Services.AddHttpClient<ICartService, CartService>();

SD.CouponApiBase = builder.Configuration["ServiceUrls:CouponAPI"];
//SD.AuthApiBase = builder.Configuration["ServiceUrls:AuthAPI"];
//SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];
//SD.ShoppingCartAPIBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"];
//builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();

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
