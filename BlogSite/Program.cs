var builder = WebApplication.CreateBuilder(args);

//Configure Services?
builder.Services.AddControllersWithViews();

var app = builder.Build();


//Configure
app.UseRouting();

//app.MapGet("/", () => "Hello World!");

//Default endpoint semasi ({controller:Home}/{action:Index}/{id?}) 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=Index}/{id?}"
    );

app.Run();
