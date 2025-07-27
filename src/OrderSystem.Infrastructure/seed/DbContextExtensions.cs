using OrderSystem.Domain.Entities;
using OrderSystem.Domain.Enums;

namespace OrderSystem.Infrastructure.seed;
public static class DbContextExtensions
{
    public static void SeedDatabase(this AppDbContext context)
    {
        if (!context.Products.Any())
        {
            var product1 = new Domain.Entities.Product { Id = Guid.NewGuid(), Name = "Laptop", Price = 1000, Stock = 10 };
            var product2 = new Domain.Entities.Product { Id = Guid.NewGuid(), Name = "Phone", Price = 500, Stock = 20 };
            var product3 = new Domain.Entities.Product { Id = Guid.NewGuid(), Name = "Headphones", Price = 100, Stock = 30 };

            context.Products.AddRange(product1, product2, product3);

            var customerId = Guid.NewGuid();
            var orderId = Guid.NewGuid();
            var orderItem1 = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = product1.Id,
                Quantity = 1,
                UnitPrice = 1000,
                Discount = 0
            };
            var orderItem2 = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = product2.Id,
                Quantity = 1,
                UnitPrice = 500,
                Discount = 0
            };

            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                InvoiceDate = DateTime.Now,
                TotalAmount = 1500
            };

            var order = new Domain.Entities.Order
            {
                Id = orderId,
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                TotalAmount = 1500,
                PaymentMethod = PaymentMethod.CreditCard,
                Status = OrderStatus.Delivered,
                OrderItems = new List<OrderItem> { orderItem1, orderItem2 }
            };

            var customer = new Customer
            {
                Id = customerId,
                Name = "Mohammad Ayman",
                Email = "mohammad@example.com",
                Orders = [order]
            };

            context.Customers.Add(customer);
        }

        context.SaveChanges();
    
    }
}
