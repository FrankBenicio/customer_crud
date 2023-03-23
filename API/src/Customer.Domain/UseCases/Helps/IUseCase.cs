namespace Customer.Domain.UseCases.Helps
{
    public interface IUseCase<in TRequest, TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute(TRequest request);
    }

    public interface IUseCase<TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute();
    }
}
