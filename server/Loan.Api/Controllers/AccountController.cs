using AutoMapper;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Model.Account;
using Microsoft.AspNetCore.Mvc;

namespace Loan.Api.Controllers
{

    [Route(AccountRoutes.ROUTE)]
    //[Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDomain _domain;
        private readonly IMapper _mapper;
        public AccountController(IAccountDomain domain, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _domain = domain ?? throw new ArgumentNullException(nameof(domain));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            var accounts = await _domain.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<AccountDto>>(accounts));
        }


        [HttpGet(AccountRoutes.ID, Name = AccountRoutes.GET_ACCOUNT_ROUTE_NAME)]
        public async Task<ActionResult<AccountDto>> GetAccount(int id, bool includeTransactions = false)
        {
            var account = await _domain.GetByIdAsync(id, includeTransactions);

            return Ok(_mapper.Map<AccountDto>(account));
        }


        [HttpPost]
        public async Task<ActionResult<AccountDto>> Create(CreateAccountDto account)
        {
            var newAccount = _mapper.Map<Account>(account);
            await _domain.CreateAsync(newAccount);

            var createdAccount = _mapper.Map<AccountDto>(newAccount);

            return CreatedAtRoute(AccountRoutes.GET_ACCOUNT_ROUTE_NAME, new { id = newAccount.Id }, createdAccount);
        }

        [HttpPut(AccountRoutes.ID)]
        public async Task<ActionResult> Update(int id, UpdateAccountDto account)
        {
            var updatedAccount = new Account();
            _mapper.Map(account, updatedAccount);
            updatedAccount.Id = id;

            var result = await _domain.UpdateAsync(updatedAccount);

            if (result)
            {
                return Ok(_mapper.Map<AccountDto>(updatedAccount));
            }
            else
            {
                return BadRequest(updatedAccount);
            }
        }

        [HttpDelete(AccountRoutes.ID)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _domain.DeleteAsync(id);

            if (!result)
                return BadRequest(id);

            return Ok(id);

        }

        [HttpGet(AccountRoutes.SEARCH)]
        public async Task<ActionResult<IEnumerable<AccountDto>>> SearchAsync(string filter)
        {
            var accounts = await _domain.SearchAsync(filter);

            if (accounts == null)
                return BadRequest($"Filter account by {filter} returned no result.");

            return Ok(_mapper.Map<IEnumerable<AccountDto>>(accounts));
        }

        [HttpPut(AccountRoutes.APPROVE)]
        public async Task<ActionResult> Approve(int id, CreateAccountCommentDto comment)
        {
            var result = await _domain.Approve(id, comment.Comment);

            var account = await _domain.GetByIdAsync(id);

            if (result)            
                return Ok(_mapper.Map<AccountDto>(account));            
            else            
                return BadRequest(_mapper.Map<AccountDto>(account));
            
        }

        [HttpPut(AccountRoutes.CANCEL)]
        public async Task<ActionResult> Cancel(int id, CreateAccountCommentDto comment)
        {
            var result = await _domain.Cancel(id, comment.Comment);

            var account = await _domain.GetByIdAsync(id);

            if (result)
                return Ok(_mapper.Map<AccountDto>(account));
            else
                return BadRequest(_mapper.Map<AccountDto>(account));
        }

        [HttpPut(AccountRoutes.DECLINE)]
        public async Task<ActionResult> Decline(int id, CreateAccountCommentDto comment)
        {
            var result = await _domain.Decline(id, comment.Comment);

            var account = await _domain.GetByIdAsync(id);

            if (result)
                return Ok(_mapper.Map<AccountDto>(account));
            else
                return BadRequest(_mapper.Map<AccountDto>(account));
        }

    }
}
