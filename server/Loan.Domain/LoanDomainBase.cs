
using AutoMapper;

namespace Loan.Domain
{
    public class LoanDomainBase
    {
        protected readonly IMapper _mapper;
        public LoanDomainBase( IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        protected ICollection<T> MapCollection<T>(ICollection<T> source, ICollection<T> destination, Func<T, T, bool> Equals) where T : class
        {
            foreach(var sourceItem in source)
            {
                var destinationItem = destination.FirstOrDefault((dest) => Equals(dest, sourceItem));
                if(destinationItem != null)                
                    destinationItem = _mapper.Map(sourceItem, destinationItem);
                else
                {
                    destination.Add(sourceItem);
                }                    
            }
            return destination;
        }
    }
}
