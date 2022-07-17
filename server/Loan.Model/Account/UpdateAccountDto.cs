using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class UpdateAccountDto : AccountDtoBase
    {
        [Required]
        public int Id { get; set; }
        
        public ICollection<CreateAccountCommentDto> AccountComments { get; set; } = new List<CreateAccountCommentDto>();

    }
}
