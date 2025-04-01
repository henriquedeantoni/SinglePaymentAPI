namespace SinglePaymentAPI.Services.Authorizer
{
    public interface IAuthorizerServices
    {
        Task<bool> AuthorizeAsync();
    }
}
