//using Microsoft.EntityFrameworkCore;
//using StoreOfBuild.Data;

using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.DI;
using StoreOfBuild.Domain;
using StoreOfBuild.Web.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ApplicationDbContext>(options => {
//    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreOfBuildDbContext"));
//});


//Add Class DI (DDD)
Bootstrap.Configure(builder.Services, builder.Configuration.GetConnectionString("StoreOfBuildDbContext"));

builder.Services.AddMvc(config =>
{
    config.Filters.Add(typeof(CustomExceptionFilter));
});

var app = builder.Build();

// N�o sera adicionado aqui pois utilizaremos um projeto responsavel pela INJE��O DE DEPENCIA
//using (var scope = app.Services.CreateScope()) 
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    if (!dbContext.Database.CanConnect())
//        throw new NotImplementedException("Can't connect to DB");
//}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseAntiforgery();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Use(async (context, next) =>
{
    //Request
    await next.Invoke();
    //Response
    var UnitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
    await UnitOfWork.Save();
}
);

app.Run();
