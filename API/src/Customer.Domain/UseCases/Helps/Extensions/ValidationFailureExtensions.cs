using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Customer.Domain.UseCases.Helps.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ValidationFailureExtensions
    {
        public static IEnumerable<ErrorMessage> ToErrorMessages(this IEnumerable<ValidationFailure> failures)
        {
            return failures.Select(x => new ErrorMessage(x.ErrorCode, x.ErrorMessage));
        }
    }
}
