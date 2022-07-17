using Loan.Model.Lookup;
using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class AccountTransactionDtoBase
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Specify the date for the transaction.")]
        public DateTime TransactionDate { get; set; } = new DateTime(1900, 1, 1);

        [Required(ErrorMessage = "Specify the expected amount for the transaction.")]
        public decimal ExpectedAmount { get; set; } = 0;

        [Required(ErrorMessage = "Specifiy the actual amount for the transaction.")]
        public decimal ActualAmount { get; set; } = 0;
        public int TransactionTypeId { get; set; }

        public LookupDto TransactionType { get; set; } = null!;
    }
}
