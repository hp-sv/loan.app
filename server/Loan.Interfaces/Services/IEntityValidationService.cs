
using Loan.Entity;
using Loan.Interface.Exceptions;

namespace Loan.Interface.Services
{
    public interface IEntityValidationService<T>
    {
        public Task ValidateForCreate(T entity);
        public Task ValidateForUpdate(T entity);
        public Task ValidateForDelete(T entity);

        public bool HasError { get; }
        public List<ValidationError> Errors { get; }

        public HttpResponseException GetException();

        public HttpResponseException CreateException(int errorCode, string errorMessage);

    }
}
