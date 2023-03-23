namespace Customer.Domain.UseCases.Interfaces
{
    public interface IGetByFilterCustomer : IUseCase<CustomerQuery, List<Models.Customer>>
    {
    }
}
