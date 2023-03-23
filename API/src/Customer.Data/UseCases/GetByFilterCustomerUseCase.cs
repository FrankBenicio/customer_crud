using Microsoft.EntityFrameworkCore;
using static Customer.Domain.UseCases.Helps.UseCaseResponseFactory<System.Collections.Generic.List<Customer.Domain.Models.Customer>>;

namespace Customer.Data.UseCases
{
    public class GetByFilterCustomerUseCase : IGetByFilterCustomer
    {
        private readonly CustomerContext context;

        public GetByFilterCustomerUseCase(CustomerContext context)
        {
            this.context = context;
        }

        public async Task<UseCaseResponse<List<Domain.Models.Customer>>> Execute(CustomerQuery request)
        {
            var dbSet = context.Customers.AsQueryable();

            if (request.Cpf is not null)
                dbSet = dbSet.Where(x => x.Cpf == request.Cpf);

            if (request.Name is not null)
                dbSet = dbSet.Where(x => x.Name == request.Name);

            var result = await dbSet.ToListAsync();

            return Ok(result);
        }
    }
}
