using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Loan.Entity;

namespace Loan.Api.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {   
            CreateMap<Account, Model.Account.AccountDto>();

            CreateMap<AccountTransaction, Model.Account.AccountTransactionDto>();
            CreateMap<AccountComment, Model.Account.AccountCommentDto>();

            CreateMap<Model.Account.CreateAccountDto, Account>()
                 .ForMember(dest => dest.Client, act => act.Ignore());

            CreateMap<Model.Account.CreateAccountTransactionDto, AccountTransaction>();
            CreateMap<Model.Account.CreateAccountCommentDto, AccountComment>();

            CreateMap<Model.Account.UpdateAccountDto, Account>()
                .ForMember(dest => dest.Client, act => act.Ignore());

            CreateMap<Model.Account.AccountCommentDto, AccountComment>()
                .EqualityComparison((dto, o) => dto.Id == o.Id);

            CreateMap<PagedResult<Account>, Model.PagedResultDto<Model.Account.AccountDto>>();
                        
        }
    }
}
