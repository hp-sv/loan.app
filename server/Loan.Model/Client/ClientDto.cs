using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Client
{
    public class ClientDto: ClientDtoBase
    {
        [Required(ErrorMessage="The client identity is required.")]
        public int Id { get; set; }

        public ClientDto? EmergencyContact { get; set; }
        public int? EmergencyContactId { get; set; }
        
    }
}
