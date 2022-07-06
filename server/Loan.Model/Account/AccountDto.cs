using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class AccountDto : AccountDtoBase
    {
        [Required]
        public int Id { get; set; }

        public ICollection<AccountTransactionDto> AccountTransactions { get; set; }
        public decimal ActualRepayments => AccountTransactions.Sum(at => at.ActualAmount);
        public decimal ExpectedRepayments => AccountTransactions.Sum(at => at.ExpectedAmount);
        public decimal Balance => (TotalAmount * (1 + Rate)) - ActualRepayments;
        
    }
}
