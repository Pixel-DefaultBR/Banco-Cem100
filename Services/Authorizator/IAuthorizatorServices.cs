namespace BancoCem.Services.Authorizator
{
    public interface IAuthorizatorServices
    {
        Task<bool> AuthorizeAsync();
    }
}
