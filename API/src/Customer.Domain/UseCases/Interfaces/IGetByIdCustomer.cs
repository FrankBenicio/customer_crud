namespace Customer.Domain.UseCases.Interfaces
{
    public interface IGetByIdCustomer : IUseCase<Guid, Models.Customer>
    {
    }
}
