namespace OrderSystem.Application.Customer.Queries.GetCustomers;
public record Response 
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Email { get; init; } = null!;

    public List<CustomerOrdersRecord> Orders { get; init; } = [];
}


public record CustomerOrdersRecord
{
    public Guid OrderId { get; init; }
    public DateTime OrderDate { get; init; }
    public decimal TotalAmount { get; init; }
    public string Status { get; init; } = null!;
}