using Loan.Model.Client;
using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class AccountDtoBase
    {
        [Required(ErrorMessage = "Specify the client for this account.")]
        public int ClientId { get; set; }

        public ClientDto Client { get; set; }             

        [Required(ErrorMessage = "Specify the rate for this account.")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Specify the amount for this account.")]
        public decimal Principal { get; set; }

        [Required(ErrorMessage = "Specify the duration for this account.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Specify the duration type for this account.")]
        public int DurationTypeId { get; set; }

        [Required(ErrorMessage = "Specify the repayment type for this account.")]
        public int RepaymentTypeId { get; set; }

        [Required(ErrorMessage = "Specify the status of this account.")]
        public int StatusId { get; set; }

        public DateTime? StartDate { get; set; }
        public decimal? Interest  { get; set; }

    }
}
