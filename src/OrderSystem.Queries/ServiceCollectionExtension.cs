using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.Common;

namespace OrderSystem.Queries;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        SqlMapper.AddTypeHandler(new GuidTypeHandler());
        
        services.AddScoped<IDbConnection>(sp =>
            sp.GetRequiredService<DbConnection>());


        #region Product
        services.AddScoped<Product.GetAll.IRepository, Product.GetAll.Repository>();
        services.AddScoped<Product.GetById.IRepository, Product.GetById.Repository>();
        #endregion

        #region Order
        services.AddScoped<Order.GetAll.IRepository, Order.GetAll.Repository>();
        services.AddScoped<Order.GetById.IRepository, Order.GetById.Repository>();
        #endregion

        #region Customer
        services.AddScoped<Customer.Exists.IRespository, Customer.Exists.Repository>();
        services.AddScoped<Customer.GetAllCustomers.IRepository, Customer.GetAllCustomers.Repository>();
        services.AddScoped<Customer.GetAllOrders.IRepository, Customer.GetAllOrders.Repository>();
        #endregion

        #region Invoices
        services.AddScoped<Invoices.GetById.IRepository, Invoices.GetById.Repository>();
        services.AddScoped<Invoices.GetAll.IRepository, Invoices.GetAll.Repository>();
        #endregion

        return services;
    }

}
