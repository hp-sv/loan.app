
using Loan.Model.Lookup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Model.Account
{
    public class AccountCommentDtoBase
    {        
        [Required]
        public int AccountId { get; set; }

        [ForeignKey("StatusId")]
        public LookupDto? Status { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Specify your comment.")]
        [MaxLength(500, ErrorMessage = "Five hundred characters is the maximum length allowed for a comment.")]
        public string Comment { get; set; }
        
    }
}
