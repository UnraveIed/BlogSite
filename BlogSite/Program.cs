using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Configure Services?
builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<Context>();


builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

//Giris yapmamis kisileri ayni sayfaya yonlendiriyor.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x=>
    {
        x.LoginPath = "/Login/Index";
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.AccessDeniedPath = new PathString("/Login/AccessDenied/");
    options.LoginPath = "/Login/Index/";
    options.SlidingExpiration = true;
});

var app = builder.Build();


//Configure metodu

//CSS gibi kutuphanelerin calismasi icin yazilmasi sart
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Error Page Yapisi icin
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1/","?code={0}");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//app.MapGet("/", () => "Hello World!");

//Default endpoint semasi ({controller:Home}/{action:Index}/{id?}) 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Blog}/{action=Index}/{id?}");
});

app.Run();
