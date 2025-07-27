namespace OrderSystem.Domain.Exceptions;
public sealed class HandledException(string message) : Exception(message)
{
}
