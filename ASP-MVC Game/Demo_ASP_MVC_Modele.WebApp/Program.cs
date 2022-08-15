using Demo_ASP_MVC_Modele.BLL.Interfaces;
using Demo_ASP_MVC_Modele.BLL.Services;
using Demo_ASP_MVC_Modele.DAL.Interfaces;
using Demo_ASP_MVC_Modele.DAL.Repositories;
using Demo_ASP_MVC_Modele.WebApp.Infrastructure;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(
    options => {
        options.Cookie.Name = "DemoASP";
        options.IdleTimeout = TimeSpan.FromMinutes(10);
        options.Cookie.HttpOnly = true;
});


builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddScoped<IGameRepository, GameRepository>();


builder.Services.AddScoped<IMemberRepository, MemberRepository>();


builder.Services.AddScoped<IMemberService, MemberService>();


builder.Services.AddScoped<IDbConnection>(sp =>
{
    return new SqlConnection(builder.Configuration.GetConnectionString("default"));
});


builder.Services.AddScoped<SessionManager>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();


app.UseSession();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
