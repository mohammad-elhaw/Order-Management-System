namespace OrderSystem.Domain.Exceptions;
public sealed class UnHandledException(string message) : Exception(message)
{
}
