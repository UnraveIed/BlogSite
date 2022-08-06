var builder = WebApplication.CreateBuilder(args);

//Configure Services?
builder.Services.AddControllersWithViews();

var app = builder.Build();


//Configure metodu

//CSS gibi kutuphanelerin calismasi icin yazilmasi sart
app.UseStaticFiles();

app.UseRouting();

//app.MapGet("/", () => "Hello World!");

//Default endpoint semasi ({controller:Home}/{action:Index}/{id?}) 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Blog}/{action=Index}/{id?}");
});

app.Run();
