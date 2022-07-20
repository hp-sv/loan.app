using AutoMapper;

namespace Loan.Entity.Profiles
{
    public class AccountProfile : Profile 
    {
        public AccountProfile()
        {
            CreateMap<Account, Account>()
                .ForMember(dest => dest.VersionNo, act => act.Ignore())
                .ForMember(dest => dest.RecordStatusId, act => act.Ignore())
                .ForMember(dest => dest.TotalAmount, act => act.Ignore())
                .ForMember(dest => dest.Interest, act => act.Ignore())
                .ForMember(dest => dest.Client, act => act.Ignore())
                .ForMember(dest => dest.AccountComments, act => act.Ignore())
                .ForMember(dest => dest.AccountTransactions, act => act.Ignore());

            CreateMap<AccountTransaction, AccountTransaction>()
                .ForMember(dest => dest.VersionNo, act => act.Ignore())
                .ForMember(dest => dest.RecordStatusId, act => act.Ignore());

            CreateMap<AccountComment, AccountComment>()
                .ForMember(dest => dest.VersionNo, act => act.Ignore())
                .ForMember(dest => dest.RecordStatusId, act => act.Ignore());

        }
    }
}
