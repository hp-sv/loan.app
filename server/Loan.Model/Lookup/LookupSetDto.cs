using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Lookup
{
	public class LookupSetDto: LookupDtoBase
	{
		[Required]
		public int Id { get; set; }

		public ICollection<LookupDto> Lookups { get; set; }
	}
}
