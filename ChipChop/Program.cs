using chipchop.Core.Interface;
using chipchop.Core.service;
using chipchop.Datalayer.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<DatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IAdmin, AdminService>();
builder.Services.AddScoped<IShopping,ShopService>(); 

const string scheme = "chipchop";

builder.Services.AddAuthentication(scheme).AddCookie(scheme,option =>
{

    option.LoginPath = "/account/login";
    option.AccessDeniedPath = "/account/login";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);

});
var app = builder.Build();
//app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute( 
        name: "Admin",
        pattern: "{area:exists}/{controller=owner}/{action=index}/{id?}");


    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=chip}/{action=index}/{id?}");

});
app.Run();
