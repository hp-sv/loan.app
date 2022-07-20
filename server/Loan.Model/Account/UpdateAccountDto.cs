using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class UpdateAccountDto : AccountDtoBase
    {
        [Required]
        public int Id { get; set; }
        
        public ICollection<AccountCommentDto> AccountComments { get; set; } = new List<AccountCommentDto>();
        public ICollection<AccountTransactionDto> AccountTransactions { get; set; } = new List<AccountTransactionDto>();

    }
}
