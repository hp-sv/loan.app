using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Entity
{
    public class EntityBase : ILoanEntity 
    {
        [Required(ErrorMessage = "Must specify the user who created this record.", AllowEmptyStrings = false)]
        [MaxLength(255)]
        public string CreateBy { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; }

        [MaxLength(255)]
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }

        [Required(ErrorMessage = "Must specify the transaction identity when this record was created.", AllowEmptyStrings = false)]
        public Guid TransactionId { get; set; }

        [ConcurrencyCheck]
        public int VersionNo { get; set; } = 0;
        public int RecordStatusId { get; set; } = 0;

        [NotMapped]
        public int OriginalPrimaryKeyValue { get; set; }
    }
}
