using Microsoft.EntityFrameworkCore;
using static Customer.Domain.UseCases.Helps.UseCaseResponseFactory<System.Collections.Generic.List<Customer.Domain.Models.Customer>>;
namespace Customer.Data.UseCases
{
    public class GetAllCustomerUseCase : IGetAllCustomer
    {
        private readonly CustomerContext context;

        public GetAllCustomerUseCase(CustomerContext context)
        {
            this.context = context;
        }

        public async Task<UseCaseResponse<List<Domain.Models.Customer>>> Execute()
        {
            var result = await context.Customers.ToListAsync();
            return Ok(result);
        }
    }
}
