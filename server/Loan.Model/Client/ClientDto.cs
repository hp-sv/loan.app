using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Client
{
    public class ClientDto: ClientDtoBase
    {
        [Required(ErrorMessage="The client identity is required.")]
        public int Id { get; set; }

        public ClientDto EmergencyContact { get; set; } = EmptyClientDto.Instance;

        public decimal Principal { get; set; }
        public decimal Balance { get; set; }

        public UpdateClientDto CreateUpdateDto()
        {
            return new UpdateClientDto { 
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                MobileNumber = this.MobileNumber,
                EmailAddress = this.EmailAddress,
                AddressLine1 = this.AddressLine1,
                AddressLine2 = this.AddressLine2,
                AddressLine3 = this.AddressLine3
            };
        }
    }
}
