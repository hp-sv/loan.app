using Loan.Interface.Services;

namespace Loan.Test
{
    internal class TestDateService : IDateService
    {
        private DateTime _currentDate;
        public TestDateService(DateTime currentDate)
        {
            _currentDate = currentDate;
        }

        public DateTime CurrentDate { get { return _currentDate; } }
        public DateTime SytemStartDate { get { return new DateTime(1900, 1, 1); } }

        public void SetCurrentDate(DateTime currentDate)
        {
            _currentDate = currentDate;
        }

        public void AddDays(int days)
        {
            _currentDate = _currentDate.AddDays(days);
        }
        
        public void AddMonths(int months)
        {
            _currentDate = _currentDate.AddMonths(months);
        }

        public void AddYears(int years)
        {
            _currentDate = _currentDate.AddYears(years);
        }
    }
}
