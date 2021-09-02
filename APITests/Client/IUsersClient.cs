using APITests.Helpers;
using Refit;
using System.Threading.Tasks;

namespace APITests.Client
{
    public interface IUsersClient
    {
        [Get("/users/{id}")]
        Task<ApiResponse<UserResponse.Root>> GetUserById(string id, [Header("Content-Type")] string contentType);
    }
}
