namespace IdentityStore.API.Services
{
    public interface IRedirectService
    {
        string ExtractRedirectUriFromReturnUrl(string url);
    }
}
