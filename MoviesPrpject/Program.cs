using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependecyResolvers.Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//---------------------------------------------------------------------------------------------------------------------------


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build();                            // proje genelinde eriþim yasaðý gibi kimse bir yere giremez.
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)                  // tüm sayfalarý login sayfasýna yönlendir.
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });




builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());        //for dependency injections
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddSession();                                                          // oturumu ekle


//---------------------------------------------------------------------------------------------------------------------------


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
//---------------------------------------------------------------------------------------------------------------------------

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");                   // olmayan sayfalar için

app.UseSession();                                                                       // oturumu kullan

app.UseAuthentication();

//---------------------------------------------------------------------------------------------------------------------------



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
