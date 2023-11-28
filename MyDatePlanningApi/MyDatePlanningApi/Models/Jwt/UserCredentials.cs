namespace MyDatePlanningApi.Models.Jwt
{
    public class UserCredentials
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
