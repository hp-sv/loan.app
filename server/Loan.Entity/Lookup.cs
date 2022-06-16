
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Entity
{
    public class Lookup: SeedEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0!;

        [Required(ErrorMessage ="Specify the name of this reference value.")]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Describe this reference value.")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("LookupSetId")]
        public LookupSet LookupSet { get; set; } = null!;
        public int LookupSetId { get; set; }
        
    }
}
