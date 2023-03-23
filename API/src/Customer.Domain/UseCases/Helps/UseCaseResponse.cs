using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Customer.Domain.UseCases.Helps
{
    [ExcludeFromCodeCoverage]
    public sealed record UseCaseResponse<T>
    {
        public UseCaseResponseKind Status { get; init; }
        public T Result { get; init; }
        public IEnumerable<ErrorMessage> Errors { get; init; }

        private int StatusCode => (int)Status;
        public bool IsSuccessful => StatusCode is > 0 and < 300;
    }
}
