using APITests.Client;
using APITests.Helpers;
using Refit;
using System.Configuration;

namespace APITests.Services
{
   public class UserServices
    {
        private readonly IUsersClient _usersClient;

        public UserServices()
        {
            _usersClient = RestService.For<IUsersClient>(ConfigurationManager.AppSettings["BaseUrl"]);
        }
        public ApiResponse<UserResponse.Root> GetUserById(string id)
        {
            return _usersClient.GetUserById(id, "application/json").GetAwaiter().GetResult();
        }
    }
}
