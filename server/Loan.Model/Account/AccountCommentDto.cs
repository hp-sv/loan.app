using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class AccountCommentDto: AccountCommentDtoBase
    {
        [Required]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
