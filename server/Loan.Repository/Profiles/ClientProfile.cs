using AutoMapper;
using Loan.Entity;

namespace Loan.Repository.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, Client>()
                .ForMember(dest => dest.VersionNo, act => act.Ignore())
                .ForMember(dest => dest.RecordStatusId, act => act.Ignore())                
                ;
        }
    }
}
