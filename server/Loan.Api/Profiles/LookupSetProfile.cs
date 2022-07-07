using AutoMapper;
using Loan.Entity;
namespace Loan.Api.Profiles
{
	public class LookupSetProfile: Profile	
	{
        public LookupSetProfile()
        {
            CreateMap<LookupSet, Model.Lookup.LookupSetDto>();
            CreateMap<Lookup, Model.Lookup.LookupDto>();

            CreateMap<Model.Lookup.LookupSetDto, LookupSet>();
            CreateMap<Model.Lookup.LookupDto, Lookup>();
            
        }
    }
}
