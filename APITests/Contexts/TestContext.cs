using APITests.Helpers;
using Refit;

namespace APITests.Contexts
{
    public class TestContext
    {
        public ApiResponse<UserResponse.Root> UserResponse { get; set; }
        public string Id { get; set; }
    }
}
