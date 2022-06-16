namespace Loan.Interface.Services
{
    public interface IChangeTransactionScope
    {
        public string CurrentUser { get; }
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; }
        public string TransactionPath { get; }

    }
}
