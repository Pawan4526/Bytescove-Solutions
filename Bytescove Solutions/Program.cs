using Bytescove_Solutions.CommonServices;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/HandleError");
}
else
{
    app.UseExceptionHandler("/Home/HandleError");

    var options = new RewriteOptions();
    options.AddRedirectToHttps();
    options.Rules.Add(new RedirectToWwwRule());
    app.UseRewriter(options);
}

app.Use(async (context, next) => {
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Error404";
        await next();
    }
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
