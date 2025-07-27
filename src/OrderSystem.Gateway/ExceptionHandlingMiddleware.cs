using OrderSystem.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Order_Management_System;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(HandledException ex)
        {
            await HandleException(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (UnHandledException ex)
        {
            await HandleException(context, HttpStatusCode.InternalServerError, 
                "An unexpected error occurred.");
        
        }
        catch (Exception ex)
        {
            await HandleException(context, HttpStatusCode.InternalServerError, "Something went wrong.");
        }
    }

    private static Task HandleException(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new
        {
            context.Response.StatusCode,
            message
        });

        return context.Response.WriteAsync(result);
    }
}
