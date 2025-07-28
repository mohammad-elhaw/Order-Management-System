using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace OrderSystem.Infrastructure;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var sqliteConnection = new SqliteConnection("DataSource=app.db");
        sqliteConnection.Open();

        services.AddSingleton<DbConnection>(sqliteConnection);

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(sqliteConnection));


        #region Product
        services.AddScoped<Product.Add.IRepository, Product.Add.Repository>();
        services.AddScoped<Product.Update.IRepository, Product.Update.Repository>();
        #endregion

        #region Order
        services.AddScoped<Order.Add.IRepository, Order.Add.Repository>();
        services.AddScoped<Order.Update.IRepository, Order.Update.Repository>();
        #endregion

        #region Customer
        services.AddScoped<Customer.Add.IRepository, Customer.Add.Repository>();
        #endregion
        //services.AddDbContext<AppIdentityDbContext>(options =>
        //    options.UseInMemoryDatabase("IdentityDb"));

        //services.AddIdentityCore<ApplicationUser>(options =>
        //{
        //    options.User.RequireUniqueEmail = true;
        //    options.Password.RequireDigit = false;
        //    options.Password.RequireLowercase = false;
        //    options.Password.RequireNonAlphanumeric = false;
        //    options.Password.RequireUppercase = false;
        //    options.Password.RequiredLength = 6;
        //})
        //    .AddEntityFrameworkStores<AppIdentityDbContext>()
        //    .AddDefaultTokenProviders();

        return services;
    }
}
