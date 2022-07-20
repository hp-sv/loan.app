
using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Lookup
{
	public class LookupDtoBase: DtoBase
	{
        
        [Required(ErrorMessage = "Specify the name of this reference value.")]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Describe this reference value.")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
               

    }
}
