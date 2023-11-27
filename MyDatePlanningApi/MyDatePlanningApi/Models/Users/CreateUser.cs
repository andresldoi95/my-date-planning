namespace MyDatePlanningApi.Models.Users
{
    public class CreateUser
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PasswordConfirmation { get; set; }
        public required string LoginName { get; set; }
    }
}
