using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class CreateAccountCommentDto
    {        
        [Required(ErrorMessage = "Specify the account for this comment.")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Specify the comment.")]
        [MaxLength(1000, ErrorMessage = "One thousand characters is the maximum length allowed for a comment.")]
        public string Comment { get; set; }

    }
}
