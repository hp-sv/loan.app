using Loan.Interface.Services;
using System.Security.Claims;

namespace Loan.Api.Service
{
    public class LoanTransactionScope : IChangeTransactionScope
    {        
        private readonly DateTime _transactionDate;                
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDateService _dateService;

        public LoanTransactionScope(IHttpContextAccessor httpContextAccessor, IDateService dateService)
        {
            _dateService = dateService ?? throw new ArgumentNullException(nameof(dateService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));         

            TransactionId = Guid.NewGuid();
            _transactionDate = _dateService.CurrentDate;
        }

        private string GetUserIdentity()
        {
           var principal = _httpContextAccessor.HttpContext?.User;
           var claim = principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
           return claim?.ToString() + "";
        }
        private string GetTransactionPath()            
        {
            var httpContext = _httpContextAccessor.HttpContext;
            return (httpContext?.Request?.Path) ?? string.Empty;
        }

        public string CurrentUser => GetUserIdentity();

        public Guid TransactionId { get; set; }
            
        public DateTime TransactionDate => _transactionDate;
        public string TransactionPath  => GetTransactionPath();

    }
}
