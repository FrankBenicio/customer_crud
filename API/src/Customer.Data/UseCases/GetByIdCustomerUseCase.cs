using Microsoft.EntityFrameworkCore;
using static Customer.Domain.UseCases.Helps.UseCaseResponseFactory<Customer.Domain.Models.Customer>;

namespace Customer.Data.UseCases
{
    public class GetByIdCustomerUseCase : IGetByIdCustomer
    {
        private readonly CustomerContext context;

        public GetByIdCustomerUseCase(CustomerContext context)
        {
            this.context = context;
        }

        public async Task<UseCaseResponse<Domain.Models.Customer>> Execute(Guid request)
        {
            var result = await context.Customers.FirstOrDefaultAsync(x => x.Id == request);
            if (result is null)
                return NotFound(null);

            return Ok(result);
        }
    }
}
