using Microsoft.AspNetCore.Mvc;

namespace Customer.Domain.UseCases.Helps.Extensions
{
    public static class UseCaseResponseExtensions
    {
        public static ObjectResult ToObjectResult<T>(this UseCaseResponse<T> response)
        {
            return response.IsSuccessful
                ? new ObjectResult(response.Result)
                {
                    StatusCode = (int)response.Status
                }
                : new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.Status
                };
        }
    }
}
