using MyDatePlanningApi.Models.Jwt;

namespace MyDatePlanningApi.Services.Interfaces
{
    public interface IJwtAuthenticator
    {
        TokenResponse? Authenticate(string username, string password);
    }
}
