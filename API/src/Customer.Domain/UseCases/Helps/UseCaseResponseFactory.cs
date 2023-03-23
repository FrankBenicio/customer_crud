using System.Diagnostics.CodeAnalysis;

namespace Customer.Domain.UseCases.Helps
{
    [ExcludeFromCodeCoverage]
    public static class UseCaseResponseFactory<T>
    {
        public static UseCaseResponse<T> Ok(T result) => new()
        {
            Status = UseCaseResponseKind.OK,
            Result = result,
            Errors = Enumerable.Empty<ErrorMessage>()
        };

        public static UseCaseResponse<T> Processing(T result) =>
            new()
            {
                Status = UseCaseResponseKind.Processing,
                Result = result,
                Errors = Enumerable.Empty<ErrorMessage>()
            };

        public static UseCaseResponse<T> Created(T result) =>
            new()
            {
                Status = UseCaseResponseKind.Created,
                Result = result,
                Errors = Enumerable.Empty<ErrorMessage>()
            };

        public static UseCaseResponse<T> Accepted(T result) =>
            new()
            {
                Status = UseCaseResponseKind.Accepted,
                Result = result,
                Errors = Enumerable.Empty<ErrorMessage>()
            };

        public static UseCaseResponse<T> BadRequest(T result, string code, string message) =>
            new()
            {
                Status = UseCaseResponseKind.BadRequest,
                Result = result,
                Errors = new[] { new ErrorMessage(code, message) }
            };

        public static UseCaseResponse<T> BadRequest(T result, IEnumerable<ErrorMessage> errors = null) =>
            new()
            {
                Status = UseCaseResponseKind.BadRequest,
                Result = result,
                Errors = errors
            };

        public static UseCaseResponse<T> Unauthorized(T result, IEnumerable<ErrorMessage> errors = null) =>
            new()
            {
                Status = UseCaseResponseKind.Unauthorized,
                Result = result,
                Errors = errors
            };

        public static UseCaseResponse<T> Forbidden(T result, IEnumerable<ErrorMessage> errors = null) =>
            new()
            {
                Status = UseCaseResponseKind.Forbidden,
                Result = result,
                Errors = errors
            };

        public static UseCaseResponse<T> Forbidden(T result, string code, string message) =>
            new()
            {
                Status = UseCaseResponseKind.Forbidden,
                Result = result,
                Errors = new[] { new ErrorMessage(code, message) }
            };

        public static UseCaseResponse<T> NotFound(T result, IEnumerable<ErrorMessage> errors = null) =>
            new()
            {
                Status = UseCaseResponseKind.NotFound,
                Result = result,
                Errors = errors
            };

        public static UseCaseResponse<T> NotFound(T result, string code, string message) =>
            new()
            {
                Status = UseCaseResponseKind.NotFound,
                Result = result,
                Errors = new[] { new ErrorMessage(code, message) }
            };

        public static UseCaseResponse<T> NoContent(T result, IEnumerable<ErrorMessage> errors = null) =>
            new()
            {
                Status = UseCaseResponseKind.NoContent,
                Result = result,
                Errors = errors
            };

        public static UseCaseResponse<T> NoContent(T result, string code, string message) =>
            new()
            {
                Status = UseCaseResponseKind.NoContent,
                Result = result,
                Errors = new[] { new ErrorMessage(code, message) }
            };

        public static UseCaseResponse<T> Conflict(T result, IEnumerable<ErrorMessage> errors = null) =>
            new()
            {
                Status = UseCaseResponseKind.Conflict,
                Result = result,
                Errors = errors
            };

        public static UseCaseResponse<T> UnprocessableEntity(T result, IEnumerable<ErrorMessage> errors = null) =>
            new()
            {
                Status = UseCaseResponseKind.UnprocessableEntity,
                Result = result,
                Errors = errors
            };

        public static UseCaseResponse<T> InternalServerError(T result, IEnumerable<ErrorMessage> errors = null) =>
            new()
            {
                Status = UseCaseResponseKind.InternalServerError,
                Result = result,
                Errors = errors
            };

        public static UseCaseResponse<T> InternalServerError(T result, string code, string message) =>
           new()
           {
               Status = UseCaseResponseKind.InternalServerError,
               Result = result,
               Errors = new[] { new ErrorMessage(code, message) }
           };

        public static UseCaseResponse<T> Unavailable(T result) =>
            new()
            {
                Status = UseCaseResponseKind.Unavailable,
                Result = result,
                Errors = "Service Unavailable".ToErrorMessages("000")
            };
    }
}
