using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class AccountDto : AccountDtoBase
    {
        [Required]
        public int Id { get; set; }

        public ICollection<AccountTransactionDto> AccountTransactions { get; set; }
    }
}
