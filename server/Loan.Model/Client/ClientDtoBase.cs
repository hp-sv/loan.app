using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Client
{
    public class ClientDtoBase
    {
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(2, ErrorMessage = "First name must be at least two characters.")]
        [MaxLength(255, ErrorMessage = "First name can be up to 255 characters only.")]
        [DefaultValue("")]
        public string FirstName { get; set; } = String.Empty;

        [DefaultValue("")]
        public string MiddleName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Last name must be at least two characters.")]
        [MaxLength(255, ErrorMessage = "Last name can be up to 255 characters only.")]
        [DefaultValue("")]
        public string LastName { get; set; } = String.Empty;

        public DateTime Dob { get; set; } = new DateTime(1900, 1, 1);

        [MinLength(8, ErrorMessage = "Mobile number must be at least eight characters.")]
        [MaxLength(20, ErrorMessage = "Mobile number can be up to 255 characters only.")]
        [DefaultValue("")]
        public string MobileNumber { get; set; } = String.Empty;

        [DefaultValue("")]
        public string EmailAddress { get; set; } = String.Empty;


        [Required(ErrorMessage = "Address line 1 is required.")]
        [MinLength(3, ErrorMessage = "Address line 1 must be at least three characters.")]
        [MaxLength(500, ErrorMessage = "Address line 1 can be up to 500 characters only.")]
        [DefaultValue("")]
        public string AddressLine1 { get; set; } = String.Empty;

        [DefaultValue("")]
        public string AddressLine2 { get; set; } = String.Empty;

        [MinLength(3, ErrorMessage = "Address line 3 must be at least three characters.")]
        [MaxLength(500, ErrorMessage = "Address line 3 can be up to 500 characters only.")]
        [DefaultValue("")]
        public string AddressLine3 { get; set; } = String.Empty;

    }

}
