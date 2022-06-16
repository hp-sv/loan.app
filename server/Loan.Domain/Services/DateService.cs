using Loan.Interface.Services;

namespace Loan.Domain.Services
{
    public class DateService : IDateService
    {
        public DateTime CurrentDate { get { return DateTime.Now; } }
        public DateTime SytemStartDate { get {return new DateTime(1900, 1, 1);} }
    }
}
