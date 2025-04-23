
namespace Restaurants.Infrastructure.Authorization;

public static class PolicyName
{

    public const string HasNationality = "Nationality";
    public const string HasDataofBirth= "DataofBirth";
}


 
public static class AppClaimType
{

    public const string Nationality = "Nationality";
    public const string DataofBirth = "DataofBirth";
}
