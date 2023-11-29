using MyDatePlanningApi.Models.Jwt;

namespace MyDatePlanningApi.Services.Interfaces
{
    public interface IJwtAuthenticator
    {
        Task<TokenResponse?> Authenticate(string username, string password);
    }
}
