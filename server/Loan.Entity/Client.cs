using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Entity
{
    public class Client : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.", AllowEmptyStrings = false)]
        [MinLength(2, ErrorMessage = "First name must be at least two characters.")]
        [MaxLength(255, ErrorMessage = "First name can be up to 255 characters only.")]
        [DefaultValue("")]
        public string FirstName { get; set; } = String.Empty;

        [DefaultValue("")]
        public string MiddleName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Last name is required.", AllowEmptyStrings = false)]
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
        [Required(AllowEmptyStrings = true)]
        public string EmailAddress { get; set; } = String.Empty;


        [Required(ErrorMessage = "Address line 1 is required.", AllowEmptyStrings = false)]        
        [MaxLength(500, ErrorMessage = "Address line 1 can be up to 500 characters only.")]
        [DefaultValue("")]
        public string AddressLine1 { get; set; } = String.Empty;

        [DefaultValue("")]
        [MaxLength(500, ErrorMessage = "Address line 2 can be up to 500 characters only.")]
        public string AddressLine2 { get; set; } = String.Empty;

        [Required(ErrorMessage = "Address line 3 is required.", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "Address line 3 must be at least three characters.")]
        [MaxLength(500, ErrorMessage = "Address line 3 can be up to 500 characters only.")]
        [DefaultValue("")]
        public string AddressLine3 { get; set; } = String.Empty;

        public ICollection<Account> Accounts { set; get; } = new List<Account>();

        [ForeignKey("EmergencyContactId")]
        public Client? EmergencyContact { get; set; } 
        public int? EmergencyContactId { get; set; }

        public string? FullName { get; private set; }
        public string? FullAddress { get; private set; }

        public Client(string firstName, string lastName)
        {        
            FirstName = firstName;
            LastName = lastName;            
        }       

    }
}
