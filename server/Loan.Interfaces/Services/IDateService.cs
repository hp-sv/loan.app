namespace Loan.Interface.Services
{
    public interface IDateService
    {
        public DateTime CurrentDate { get; }
        public DateTime SytemStartDate { get; }                
    }
}
