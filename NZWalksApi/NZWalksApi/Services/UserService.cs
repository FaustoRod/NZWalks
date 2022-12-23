using NZWalksApi.Models;
using NZWalksApi.Services.Interfaces;

namespace NZWalksApi.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>()
        {
            new User()
            {
                Id=Guid.NewGuid(),
            FirstName= "Test",
                LastName= "Test",
                Email="test@mail.com",
                Password="123456",
                UserName="Test",
                //Roles=new List<string>{"reader"}
            },
            new User()
            {
                Id=Guid.NewGuid(),
            FirstName= "Test",
                LastName= "Test",
                Email="test2@mail.com",
                Password="123456",
                UserName="Test2",
                //Roles=new List<string>{"reader","writer"}
            }
        };

        public async Task<User> AuthenticateAsync(string username, string password)=> users.Find(user => user.Email.Equals(username) && user.Password.Equals(password));
    }
}
