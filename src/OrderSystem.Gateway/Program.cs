using OrderSystem.API;
using OrderSystem.Infrastructure;
using OrderSystem.Infrastructure.seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opts =>
    {
        opts.SuppressModelStateInvalidFilter = true;
    })
    .AddApplicationPart(typeof(AssemblyReference).Assembly);
builder.Services.AddAPI();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    try
    {
        opts.SwaggerDoc("v1", new() 
        { 
            Title = "Order System API", 
            Version = "v1",
            Description = "API documentation for Order Management System"
        });
        opts.CustomSchemaIds(type => type.FullName?.Replace("+", "."));
    }
    catch(Exception ex)
    {
        // we need to add Logger instead
        Console.WriteLine("Swagger config error", ex.Message);
        throw;
    }
});

var app = builder.Build();

// seed data
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.EnsureCreatedAsync();
    context.SeedDatabase();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order System API V1");
    });
}
app.UseMiddleware<Order_Management_System.ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
