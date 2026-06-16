namespace B2B.Services.Interfaces
{
    public interface IUserContextService
    {
        Guid GetUserId();
        string GetEmail();
        string GetRole();
        bool IsAuthenticated();
    }
}
