
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Loan.Entity
{
    public class AccountComment : EntityBase
    {
       
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("StatusId")]
        public Lookup Status { get; set; }

        [Required]
        public int StatusId { get; set; }

        [MaxLength(500, ErrorMessage = "Five hundred characters is the maximum length allowed for a comment.")]
        public string Comment { get; set; }

    }
}
