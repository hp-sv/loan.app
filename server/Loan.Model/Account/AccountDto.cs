using Loan.Interface.Constants;
using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class AccountDto : AccountDtoBase
    {
        [Required]
        public int Id { get; set; }

        public ICollection<AccountTransactionDto> AccountTransactions { get; set; } = new List<AccountTransactionDto>();
        public ICollection<AccountCommentDto> AccountComments { get; set; } = new List<AccountCommentDto>();

        public decimal ActualRepayments => AccountTransactions.Where(at=>at.TransactionTypeId == LookupIds.TransactionType.Actual).Sum(at => at.Amount);
        public decimal ExpectedRepayments => AccountTransactions.Where(at => at.TransactionTypeId == LookupIds.TransactionType.Projection).Sum(at => at.Amount);
        public decimal Balance => (Principal + Interest.Value) - ActualRepayments;
        
    }
}
