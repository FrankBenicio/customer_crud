using Customer_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Customer_Web.Services
{
    public interface ICustomerApiService
    {
        [Get("/customers")]
        Task<ApiResponse<List<Customer>>> GetAll();

        [Get("/customers/{id}")]
        Task<ApiResponse<Customer>> GetById([Query] Guid id);

        [Post("/customers/search")]
        Task<ApiResponse<List<Customer>>> GetBySearch([FromBody] CustomerQuery query);

        [Post("/customers")]
        Task<ApiResponse<bool>> Post([FromBody] Customer customer);

        [Put("/customers")]
        Task<ApiResponse<bool>> Put([FromBody] Customer customer);

        [Delete("/customers/{id}")]
        Task<ApiResponse<bool>> Remove([Query] Guid id);
    }
}
