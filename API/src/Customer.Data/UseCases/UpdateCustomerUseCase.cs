using static Customer.Domain.UseCases.Helps.UseCaseResponseFactory<bool>;

namespace Customer.Data.UseCases
{
    public class UpdateCustomerUseCase : IUpdateCustomer
    {
        private readonly CustomerValidator _requestValidator = new();
        private readonly CustomerContext context;

        public UpdateCustomerUseCase(CustomerContext context)
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

                context.Update(request);

                await context.SaveChangesAsync().ConfigureAwait(false);

                return Ok(true);

            }
            catch (Exception e)
            {
                return BadRequest(false, "Exception", e.Message);
            }
        }
    }
}
