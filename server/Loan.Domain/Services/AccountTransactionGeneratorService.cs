using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Services;
namespace Loan.Domain.Services
{
    public class AccountTransactionGeneratorService : IAccountTransactionGeneratorService
    {                
        
        private int getDuration(Account account) {

            DateTime startDate = account.StartDate.Value;
            DateTime endDate = startDate;

            switch (account.DurationTypeId)
            {
                case LookupIds.DurationType.Month:
                    endDate = startDate.AddMonths(account.Duration);
                    break;
                case LookupIds.DurationType.Week:
                    endDate = startDate.AddDays(account.Duration * 7);
                    break;
                case LookupIds.DurationType.Year:
                    endDate = startDate.AddYears(account.Duration);
                    break;
                case LookupIds.DurationType.HalfYear:
                    endDate = startDate.AddYears(account.Duration/2);
                    break;
                case LookupIds.DurationType.Quarter:
                    endDate = startDate.AddMonths(account.Duration * 3);
                    break;
            }

            return (endDate - startDate).Days;
        }

        private int getDurationDivider(Account account)
        {
            switch (account.RepaymentTypeId)
            {
                case LookupIds.RepaymentSchedule.Daily:
                    return 1;
                case LookupIds.RepaymentSchedule.Weekly:
                    return 7;
                case LookupIds.RepaymentSchedule.Monthly:
                    return 30;
                case LookupIds.RepaymentSchedule.TwiceMonthly:
                    return 15;                
                default: return 1;
            }
        }

        public List<AccountTransaction> Generate(Account account) {

            
            var principal = createAccountTransaction(account, account.StartDate.Value, account.Principal, LookupIds.TransactionType.Debit);
            principal.ActualAmount = account.Principal;
            account.AccountTransactions.Add(principal);

            var interest = createAccountTransaction(account, account.StartDate.Value, account.Interest.Value, LookupIds.TransactionType.Debit);
            interest.ActualAmount = account.Interest.Value;
            account.AccountTransactions.Add(interest);
            
            var totalDays = getDuration(account);
            var daysInterval = getDurationDivider(account);

            var totalNumberOfTransactions = Math.Ceiling(totalDays / (decimal)daysInterval);
            var totalAmount = account.TotalAmount.Value;
            decimal repaymentAmount = Math.Ceiling(totalAmount / totalNumberOfTransactions);

            var transactionDate = account.StartDate.Value.AddDays(daysInterval);

            decimal totalRepayment = 0;

            for (int numberTransaction = 1; numberTransaction <= totalNumberOfTransactions; numberTransaction++)
            {
                if ((totalAmount - totalRepayment) <= repaymentAmount)
                    repaymentAmount = (totalAmount - totalRepayment);

                account.AccountTransactions.Add(createAccountTransaction(account, transactionDate, repaymentAmount, LookupIds.TransactionType.Credit));
                transactionDate = transactionDate.AddDays(daysInterval);
                totalRepayment = totalRepayment + repaymentAmount;
            }

            return account.AccountTransactions.ToList();
            
        }
        private AccountTransaction createAccountTransaction(Account account, DateTime transactionDate, decimal amount, int transactionTypeId)
        {            
            return new AccountTransaction() {        
                AccountId = account.Id,
                Account = account,
                TransactionDate = transactionDate,
                TransactionTypeId= transactionTypeId,
                ExpectedAmount = amount,
            };
        }        
    }

    

}
