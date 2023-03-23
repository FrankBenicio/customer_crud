using Microsoft.EntityFrameworkCore;
using static Customer.Domain.UseCases.Helps.UseCaseResponseFactory<bool>;

namespace Customer.Data.UseCases
{
    public class RemoveCustomerUseCase : IRemoveCustomer
    {
        private readonly CustomerContext context;

        public RemoveCustomerUseCase(CustomerContext context)
        {
            this.context = context;
        }

        public async Task<UseCaseResponse<bool>> Execute(Guid id)
        {
            try
            {
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);

                if (customer is null)
                    return NotFound(false);

                context.Remove(customer);

                await context.SaveChangesAsync();

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(false, "Exception", e.Message);
            }
        }
    }
}
