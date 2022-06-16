using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Test.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Model.Client.CreateClientDto, Model.Client.UpdateClientDto>();
            CreateMap<Model.Client.ClientDto, Model.Client.UpdateClientDto>();
        }

    }
}
