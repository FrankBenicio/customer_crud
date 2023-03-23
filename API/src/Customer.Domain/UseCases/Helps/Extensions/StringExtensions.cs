using Customer.Domain.UseCases.Helps;
using System.Diagnostics.CodeAnalysis;

namespace Customer.Domain.UseCases.Helps.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class StringExtensions
    {
        public static IEnumerable<ErrorMessage> ToErrorMessages(this string that, string code)
        {
            return new ErrorMessage[] { new(code, that) };
        }
    }
}
