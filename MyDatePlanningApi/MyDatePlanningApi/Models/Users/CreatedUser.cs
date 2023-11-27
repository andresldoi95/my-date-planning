namespace MyDatePlanningApi.Models.Users
{
    public class CreatedUser
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string LoginName { get; set; }
        public required string Email { get; set; }
        public required DateTime CreatedDate { get; set; }
    }
}
