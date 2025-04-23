namespace Restaurants.Domain.Exceptions;

public class NotFoundException(string ResourceType ,string Identifier) : Exception($"{ResourceType} with id: {Identifier} does'nt Exist")
{
}
