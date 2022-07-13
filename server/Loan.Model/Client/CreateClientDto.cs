namespace Loan.Model.Client
{
    public class CreateClientDto : ClientDtoBase
    {
        public ClientDto? EmergencyContact { get; set; }
        public int? EmergencyContactId { get; set; }
    }
}
