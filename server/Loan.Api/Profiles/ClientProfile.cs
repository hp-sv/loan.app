using AutoMapper;
using Loan.Entity;
using Loan.Entity.Profiles;

namespace Loan.Api.Profiles
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, Model.Client.ClientDto>();            
            CreateMap<Client, Model.Client.UpdateClientDto>();            

            CreateMap<Model.Client.ClientDto, Client>();
            CreateMap<Model.Client.CreateClientDto, Client>();
            CreateMap<Model.Client.UpdateClientDto, Client>();

            CreateMap<PagedResult<Client>, Model.PagedResultDto<Model.Client.ClientDto>>();


        }

    }
}
