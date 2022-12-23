using NZWalksApi.Models;

namespace NZWalksApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> AuthenticateAsync(string username, string password);
    }
}
