using AutoMapper;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Model;
using Loan.Model.Client;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Loan.Api.Controllers
{
	[Route(ClientRoutes.ROUTE)]
    //[Authorize]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientDomain _domain;
        private readonly IMapper _mapper;
        public ClientController(IClientDomain domain, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _domain = domain ?? throw new ArgumentNullException(nameof(domain));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<ClientDto>>> GetClientsAsync(int pg, int pgSize) {
            var pageResult = await _domain.GetAllAsync(pg, pgSize);

            return Ok(_mapper.Map<PagedResultDto<ClientDto>>(pageResult));
        }

        [HttpGet(ClientRoutes.ID, Name = ClientRoutes.GET_CLIENT_ROUTE_NAME)]
        public async Task<ActionResult<ClientDto>> GetClient(int id, bool includeAccounts = false)
        {
            var client = await _domain.GetByIdAsync(id, includeAccounts);

            return Ok(_mapper.Map<ClientDto>(client));            
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateAsync(CreateClientDto client)
        {            
            var newClient = _mapper.Map<Client>(client);          

            await _domain.CreateAsync(newClient);

            var createdClient = _mapper.Map<ClientDto>(newClient);
            return CreatedAtRoute(ClientRoutes.GET_CLIENT_ROUTE_NAME, new { id = newClient.Id }, createdClient);
        }

        [HttpPut(ClientRoutes.ID)]
        public async Task<ActionResult<ClientDto>> UpdateAsync(int id, UpdateClientDto client)            
        {
            var clientToUpdate = new Client("","");
            _mapper.Map(client, clientToUpdate);
            clientToUpdate.Id = id;

            var result = await _domain.UpdateAsync(clientToUpdate);

            if (result)
            {
                return Ok(_mapper.Map<ClientDto>(clientToUpdate));
            }                
            else
            {
                return BadRequest(client);
            }
            

        }

        [HttpPatch(ClientRoutes.ID)]
        public async Task<ActionResult> PatchAsync(int id, JsonPatchDocument<UpdateClientDto> patchDoucment)
        {
            var client = await _domain.GetByIdAsync(id);
            
            UpdateClientDto clientDto= new UpdateClientDto();

            _mapper.Map(client, clientDto);

            patchDoucment.ApplyTo(clientDto, ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!TryValidateModel(clientDto))
                return BadRequest(ModelState);

            _mapper.Map(clientDto, client);
                        
            await _domain.UpdateAsync(client);

            return NoContent();

        }

        [HttpDelete(ClientRoutes.ID)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _domain.DeleteAsync(id);

            if (!result)
                return BadRequest(id);

            return Ok(id);

        }

        [HttpGet(ClientRoutes.SEARCH)]
        public async Task<ActionResult<PagedResultDto<ClientDto>>> SearchAsync(string filter, int pg, int pgSize)
        {
            var pagedResult = await _domain.SearchAsync(filter, pg, pgSize);

            if (pagedResult.RowCount == 0 )
                return BadRequest($"Filter client by {filter} returned no result.");

            return Ok(_mapper.Map<PagedResultDto<ClientDto>>(pagedResult));
        }

    }
}
