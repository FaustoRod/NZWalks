using NZWalksApi.Models;

namespace NZWalksApi.Services.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> CreateToken(User user);
    }
}
