using System.ComponentModel.DataAnnotations;


namespace Loan.Model.Lookup
{
	public class LookupSetDtoBase
	{
        [Required(ErrorMessage = "Specify the name of the lookup set.")]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Describe the lookup set.")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

    }
}
