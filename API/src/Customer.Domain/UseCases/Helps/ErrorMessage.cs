using System.Diagnostics.CodeAnalysis;

namespace Customer.Domain.UseCases.Helps
{
    [ExcludeFromCodeCoverage]
    public sealed record ErrorMessage(string Code, string Message);
}
