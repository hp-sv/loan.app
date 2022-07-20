using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Entity
{
    public class AccountTransaction :EntityBase
    {        
        [ForeignKey("AccountId")]
        public Account Account { get; set; } = null!;
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Specify the date for the transaction.")]
        public DateTime TransactionDate { get; set; } = new DateTime(1900, 1, 1);

        [Required(ErrorMessage = "Specify the expected amount for the transaction.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; } = 0;
                
        [ForeignKey("TransactionTypeId")]
        public Lookup TransactionType { get; set; } = null!;
        public int TransactionTypeId { get; set; }

        [ForeignKey("JournalEntryTypeId")]
        public Lookup JournalEntryType { get; set; } = null!;
        public int JournalEntryTypeId { get; set; }
    }
}
