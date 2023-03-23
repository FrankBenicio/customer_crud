
using FluentValidation;

namespace Customer.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Models.Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Cpf).NotEmpty().NotNull();
            RuleFor(x => x.DateOfBirth).NotEmpty().NotNull();
            RuleFor(x => x.Gender).NotEmpty().NotNull();
            RuleFor(x => x.PostalCode).NotEmpty().NotNull();
            RuleFor(x => x.Address).NotEmpty().NotNull();
            RuleFor(x => x.State).NotEmpty().NotNull();
            RuleFor(x => x.City).NotEmpty().NotNull();
        }
    }
}
