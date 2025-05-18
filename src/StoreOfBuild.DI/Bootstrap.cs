using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

namespace StoreOfBuild.DI;

public class Bootstrap
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateScopes = false
        });

        services.AddIdentity<ApplicationUser, IdentityRole>(config =>
        {
            config.Password.RequireDigit = false;
            config.Password.RequiredLength = 3;
            config.Password.RequireLowercase = false;
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequireUppercase = false;
            //config.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped(typeof(IRepository<Product>), typeof(RepositoryProduct));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IAuthentication), typeof(Authentication));
        services.AddScoped(typeof(IManager), typeof(Manager));
        services.AddScoped(typeof(CategoryStorer));
        services.AddScoped(typeof(ProductStorer));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    }
}
