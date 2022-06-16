using Loan.Entity;
using Loan.Interface.Exceptions;
using Loan.Interface.Services;
using System.Net;

namespace Loan.Domain.Services
{
    public class ValidationServiceBase<T> : IEntityValidationService<T>
    {
        protected List<ValidationError> _Erorrs = new List<ValidationError>();

        public bool HasError => _Erorrs.Any();

        public List<ValidationError> Errors => _Erorrs;
        
        public virtual Task ValidateForCreate(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual Task ValidateForUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task ValidateForDelete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual HttpResponseException GetException()
        {
            if (!HasError)
                throw new Exception("No error to report");

            return new HttpResponseException((int)HttpStatusCode.BadRequest, _Erorrs);
            
        }

        public virtual HttpResponseException CreateException(int errorCode, string errorMessage)
        {
            return new HttpResponseException(
                    (int)HttpStatusCode.BadRequest, 
                    new[] { 
                        new ValidationError { ErrorCode = errorCode, ErrorMessage=errorMessage} 
                    });
        }

    }
}
