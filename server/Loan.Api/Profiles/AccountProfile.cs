using AutoMapper;
using Loan.Entity;

namespace Loan.Api.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, Model.Account.AccountDto>();
            CreateMap<AccountTransaction, Model.Account.AccountTransactionDto>();

            CreateMap<Model.Account.CreateAccountDto, Account>();

            CreateMap<Model.Account.CreateAccountTransactionDto, AccountTransaction>();

            CreateMap<Model.Account.UpdateAccountDto, Account>();
            CreateMap<Model.Account.UpdateAccountTransactionDto, AccountTransaction>();
        }
    }
}
