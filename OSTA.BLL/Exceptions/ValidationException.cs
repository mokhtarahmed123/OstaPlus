using FluentValidation.Results;

namespace OSTA.BLL.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationFailure> errors)
            : base(string.Join("; ", errors.Select(e => e.ErrorMessage)))
        {
        }
    }
}
