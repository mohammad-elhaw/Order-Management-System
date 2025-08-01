using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrderSystem.API;
using OrderSystem.Domain.Entities;
using OrderSystem.Infrastructure;
using OrderSystem.Infrastructure.seed;
using System.Text;

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

        opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authoriztion",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'Bearer' followed by a space and your JWT token.\nExample: Bearer abcdef12345"
        });

        opts.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });

        opts.CustomSchemaIds(type => type.FullName?.Replace("+", "."));
    }
    catch(Exception ex)
    {
        // we need to add Logger instead
        Console.WriteLine("Swagger config error", ex.Message);
    }
});

builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opts =>
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")!);
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Issuer"], // Issuer name
            ValidAudience = builder.Configuration["Audience"], // Audience name
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// seed data
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    await context.Database.EnsureCreatedAsync();
    await context.SeedDatabase(roleManager, userManager);
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
