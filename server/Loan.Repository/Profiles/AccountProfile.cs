using AutoMapper;
using Loan.Entity;

namespace Loan.Repository.Profiles
{
    public class AccountProfile : Profile 
    {
        public AccountProfile()
        {
            CreateMap<Account, Account>()
                .ForMember(dest => dest.VersionNo, act => act.Ignore())
                .ForMember(dest => dest.RecordStatusId, act => act.Ignore())
                ;

            CreateMap<AccountTransaction, AccountTransaction>()
                .ForMember(dest => dest.VersionNo, act => act.Ignore())
                .ForMember(dest => dest.RecordStatusId, act => act.Ignore())
                ;
        }
    }
}
