using AutoMapper;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Model.Lookup;
using Microsoft.AspNetCore.Mvc;

namespace Loan.Api.Controllers
{
    [Route(LookupSetRoutes.ROUTE)]
    //[Authorize]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupSetDomain _domain;
        private readonly IMapper _mapper;
        public LookupController(ILookupSetDomain domain, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _domain = domain ?? throw new ArgumentNullException(nameof(domain));
        }

        [HttpGet(LookupSetRoutes.ID, Name = LookupSetRoutes.GET_LOOKUP_ROUTE_NAME)]
        public async Task<ActionResult<LookupSetDto>> GetLookupSet(int id)
        {
            var lookupSet = await _domain.GetByIdAsync(id);

            return Ok(_mapper.Map<LookupSetDto>(lookupSet));
        }

    }
}
