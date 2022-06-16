using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Loan.Entity
{
    public class ChangeEntityDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ChangeEntityId")]
        public ChangeEntity ChangeEntity { get; set; } = null!;
        public int ChangeEntityId { get; set; }

        [MaxLength(500)]
        public string ColumnName { get; set; } = string.Empty;
        
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;        
    }
}
