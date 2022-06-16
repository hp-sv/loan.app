using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Entity
{
    public class ChangeEntity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings =false)]
        [MaxLength(255)]
        public string EntityName { get; set; } = string.Empty;
        public int PrimaryKey { get; set; } = 0;

        [ForeignKey("TransactionId")]
        public ChangeTransaction ChangeTransaction { get; set; } = null!;
        public Guid TransactionId { get; set; }

        public int ChangeOperationId { get; set; }

        public ICollection<ChangeEntityDetail> ChangeEntityDetails { get; set; } = new List<ChangeEntityDetail>();

    }
}
