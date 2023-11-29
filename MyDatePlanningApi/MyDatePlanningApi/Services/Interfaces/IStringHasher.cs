namespace MyDatePlanningApi.Services.Interfaces
{
    public interface IStringHasher
    {
        string Hash(string input);
        bool CheckPassword(string input, string hashedPassword);
    }
}
