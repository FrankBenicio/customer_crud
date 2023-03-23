using static Customer.Domain.UseCases.Helps.UseCaseResponseFactory<bool>;

namespace Customer.Data.UseCases
{
    public class CreateCustomerUseCase : ICreateCustomer
    {
        private readonly CustomerValidator _requestValidator = new();
        private readonly CustomerContext context;

        public CreateCustomerUseCase(CustomerContext context)
        {
            this.context = context;
        }

        public async Task<UseCaseResponse<bool>> Execute(Domain.Models.Customer request)
        {
            try
            {
                var validationResult =
                   await _requestValidator
                       .ValidateAsync(request)
                       .ConfigureAwait(false);

                if (!validationResult.IsValid)
                {
                    return BadRequest(false, validationResult.Errors.ToErrorMessages());
                }

                await context.AddAsync(request).ConfigureAwait(false);

                await context.SaveChangesAsync().ConfigureAwait(false);

                return Created(true);

            }
            catch (Exception e)
            {
                return BadRequest(false, "Exception", e.Message);
            }
        }
    }
}
