using Loan.Model.Lookup;
using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class AccountTransactionDtoBase : DtoBase
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Specify the date for the transaction.")]
        public DateTime TransactionDate { get; set; } = new DateTime(1900, 1, 1);
                
        [Required(ErrorMessage = "Specifiy the amount for the transaction.")]
        public decimal Amount { get; set; } = 0;
        public int TransactionTypeId { get; set; }
        public LookupDto TransactionType { get; set; } = null!;
        public int JournalEntryTypeId { get; set; }
        public LookupDto JournalEntryType { get; set; } = null!;

    }
}
