using System.ComponentModel.DataAnnotations;

namespace Loan.Model.Account
{
    public class CreateAccountTransactionDto : AccountTransactionDtoBase
    {
        public int? Id { get; set; }

    }
}
