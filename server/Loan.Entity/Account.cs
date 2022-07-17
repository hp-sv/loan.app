
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Entity
{
    public class Account: EntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int Id { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; } = null!;

        [Required]
        public int ClientId { get; set; }

        [Required(ErrorMessage ="Specify the rate for this account.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Specify the amount for this account.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Principal { get; set; }

        [Required(ErrorMessage = "Specify the duration for this account.")]
        public int Duration { get; set; }
        
        
        [ForeignKey("DurationTypeId")]
        public Lookup DurationType { get; set; } =null!;

        [Required]
        public int DurationTypeId { get; set; }

        [ForeignKey("RepaymentTypeId")]
        public Lookup RepaymentType { get; set; } = null!;

        [Required] 
        public int RepaymentTypeId { get; set; }


        [ForeignKey("StatusId")]        
        public Lookup Status { get; set; }

        [Required]
        public int StatusId { get; set; }

        public DateTime? StartDate { get; set; }

        public decimal? Interest { get; set; }
        public decimal? TotalAmount { get; set; }

        public ICollection<AccountTransaction> AccountTransactions { set; get; } = new List<AccountTransaction>();
        public ICollection<AccountComment> AccountComments { get; set; } = new List<AccountComment>();

    }
}
