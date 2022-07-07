using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Lookup
{
	public class LookupDto :LookupDtoBase
	{
		[Required]
		public int Id { get; set; }
	}
}
