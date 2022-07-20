﻿using AutoMapper;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Model;
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
        public async Task<ActionResult<PagedResultDto<AccountDto>>> GetAccounts(int pg, int pgSize)
        {
            var pagedResult = await _domain.GetAllAsync(pg, pgSize);
            var pagedDto = _mapper.Map<PagedResultDto<AccountDto>>(pagedResult);

            return Ok(pagedDto);
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
                updatedAccount = await _domain.GetByIdAsync(id);
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
        public async Task<ActionResult<PagedResultDto<AccountDto>>> SearchAsync(string filter, int pg, int pgSize)
        {
            var pagedResult = await _domain.SearchAsync(filter, pg, pgSize);

            if (pagedResult.RowCount == 0)
                return BadRequest($"Filter account by {filter} returned no result.");

            return Ok(_mapper.Map<PagedResultDto<AccountDto>>(pagedResult));
        }

        [HttpPut(AccountRoutes.APPROVE)]
        public async Task<ActionResult> ApproveAsync(UpdateAccountDto account)
        {            
            var approveAccount = _mapper.Map(account, new Account());
            var result = await _domain.ApproveAsync(approveAccount);
            if (result) {
                var approvedAccount = await _domain.GetByIdAsync(approveAccount.Id);
                return Ok(_mapper.Map<AccountDto>(approvedAccount));
            }                
            else 
                return BadRequest(_mapper.Map<AccountDto>(account));
        }

        [HttpPut(AccountRoutes.CANCEL)]
        public async Task<ActionResult> CancelAsync(int id, UpdateAccountDto account)
        {
            var cancelAccount = await _domain.GetByIdAsync(id);

            if (cancelAccount != null)
            {
                var cancelledAccount = _mapper.Map(account, cancelAccount);
                var result = await _domain.CancelAsync(cancelledAccount);

                if (result)
                {
                    cancelAccount = await _domain.GetByIdAsync(id);
                    return Ok(_mapper.Map<AccountDto>(cancelAccount));
                }   
                else
                    return BadRequest(_mapper.Map<AccountDto>(account));
            }
            else
            {
                return BadRequest(_mapper.Map<AccountDto>(account));
            }
        }

        [HttpPut(AccountRoutes.DECLINE)]
        public async Task<ActionResult> DeclineAsync(int id, UpdateAccountDto account)
        {
            var declineAccount = await _domain.GetByIdAsync(id);

            if (declineAccount != null)
            {
                var declinedAccount = _mapper.Map(account, declineAccount);
                var result = await _domain.DeclineAsync(declinedAccount);
                if (result)
                {
                    declineAccount = await _domain.GetByIdAsync(id);
                    return Ok(_mapper.Map<AccountDto>(declineAccount));
                }                    
                else
                    return BadRequest(_mapper.Map<AccountDto>(account));
            }
            else
            {
                return BadRequest(_mapper.Map<AccountDto>(account));
            }
        }

        [HttpPost(AccountRoutes.COMMENT)]
        public async Task<ActionResult> AddComment(int id, CreateAccountCommentDto comment)
        {            
            var newComment = _mapper.Map<AccountComment>(comment);
            await _domain.CreateCommentAsync(newComment);

            var account = await _domain.GetByIdAsync(id);

            var udatedAccount = _mapper.Map<AccountDto>(account);

            return CreatedAtRoute(AccountRoutes.GET_ACCOUNT_ROUTE_NAME, new { id = udatedAccount.Id }, udatedAccount);
        }       

    }
}
