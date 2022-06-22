using AutoMapper;
using Loan.Entity;
using Loan.Entity.Profiles;

namespace Loan.Api.Profiles
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
           CreateMap<Client, Model.Client.ClientDto>()
                .ForMember(dest => dest.Principal, act => act.Ignore())
                .ForMember(dest => dest.Balance, act => act.Ignore());

            CreateMap<Client, Model.Client.UpdateClientDto>();

            CreateMap<Model.Client.ClientDto, Client>();

            CreateMap<Model.Client.CreateClientDto, Client>();

            CreateMap<Model.Client.UpdateClientDto, Client>();

        }

    }
}
