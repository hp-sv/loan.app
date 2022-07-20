using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Entity
{
    public class LookupSet : SeedEntityBase
    {     
        [Required(ErrorMessage = "Specify the name of the lookup set.")]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Describe the lookup set.")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;        
        
        public ICollection<Lookup> Lookups { get; set; } = new List<Lookup>();
               
        
    }
}
