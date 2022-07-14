
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Loan.Entity
{
    public class AccountComment : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
                
        [MaxLength(1000, ErrorMessage = "One thousand characters is the maximum length allowed for a comment.")]        
        public string Comment { get; set; }

    }
}
