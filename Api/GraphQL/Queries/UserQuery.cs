using EventOrchestrationService.Models;

namespace EventOrchestrationService.Api.GraphQL.Queries
{
    public class UserQuery
    {
        public User GetUser() =>
            new User
            {
                UserName = "Test",
            };
    }
}
