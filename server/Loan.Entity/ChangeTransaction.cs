using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Entity
{
    public class ChangeTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(AllowEmptyStrings = false)]        
        public Guid TransactionId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(255)]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = new DateTime(1900, 1, 1);

        [Required(AllowEmptyStrings =false)]
        public string TransactionPath { get; set; } = string.Empty;

        public ICollection<ChangeEntity> ChangeEntities { get; set; } = new List<ChangeEntity>();

    }
}
