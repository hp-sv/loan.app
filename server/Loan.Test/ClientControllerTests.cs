using AutoMapper;
using Loan.Api.Controllers;
using Loan.Data.Context;
using Loan.Domain;
using Loan.Domain.Services;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Interface.Exceptions;
using Loan.Interface.Repositories;
using Loan.Interface.Services;
using Loan.Model;
using Loan.Model.Client;
using Loan.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Loan.Test
{
    public class ClientControllerTests : IClassFixture<LoanSeedDataFixture>
    {
        private readonly IClientRepository _repository;
        private readonly IAccountRepository _accountRepository;
        private readonly IClientDomain _domain;
        private readonly IClientValidationService _validationService;
        private readonly ClientController _controller;
        private readonly IMapper _mapper;
        private readonly TestDateService _testDateService;
        private readonly LoanDbContext _loanDbContext;

        private readonly LoanSeedDataFixture _fixture;

        public ClientControllerTests(LoanSeedDataFixture fixture)
        {
            _fixture = fixture;
            _mapper = fixture.Mapper;
            _loanDbContext = fixture.DbContext;
            _testDateService = fixture.DateService;
            _repository = new ClientRepository(_loanDbContext, _mapper);
            _accountRepository = new AccountRepository(_loanDbContext, _mapper);
            _validationService = new ClientValidationService(_repository, _accountRepository, _testDateService);
            _domain = new ClientDomain(_repository, _fixture.ChangeTransactionService, _validationService, _mapper);
            _controller = new ClientController(_domain, _fixture.Mapper);
            _controller.ObjectValidator = new TestObjectValidator();
        }
        
        
        [Fact]
        public async void Can_Create_Client()
        {            
            var actionResult = await _controller.CreateAsync(_fixture.JohnDough);

            Assert.IsType<ActionResult<ClientDto>>(actionResult);
            Assert.IsType<CreatedAtRouteResult>(actionResult.Result);

            var result = actionResult.Result as CreatedAtRouteResult;

            Assert.IsType<ClientDto>(result?.Value);
            
            var createdClient = result?.Value as ClientDto;
            Assert.True(createdClient?.Id > 0);
        }

        [Fact]
        public async void Can_Update_Client()
        {
            // Create Client
            var createResult = await _controller.CreateAsync(_fixture.JohnDough);
            var result = createResult.Result as CreatedAtRouteResult;
            var createdClient = result?.Value as ClientDto;

            var updateClient = new UpdateClientDto();

            _mapper.Map(createdClient, updateClient);

            updateClient.FirstName = "James";
            updateClient.LastName = "Ohara";
            updateClient.Dob = new DateTime(1980, 02, 28);

           var updateResult = await _controller.UpdateAsync(createdClient.Id, updateClient);

            Assert.IsType<ActionResult<ClientDto>>(updateResult);
        }

        [Fact]
        public async Task Can_Delete_Client()
        {            
            var deleteClient = _loanDbContext.Clients.Where(c=> !c.Accounts.Any(a=>a.StatusId == LookupIds.AccountStatuses.Active)).First();
            var deleteResult = await _controller.DeleteAsync(deleteClient.Id);

            Assert.IsType<OkObjectResult>(deleteResult);

            var deletedClient = _fixture.DbContext.Clients.Where(c=>c.Id == deleteClient.Id).FirstOrDefault();
            Assert.Null(deletedClient);

        }

        [Fact]
        public async void Can_Patch_Client()
        {   
            var patchDoc = new JsonPatchDocument<UpdateClientDto>();
            var client = _loanDbContext.Clients.First();

            patchDoc.Replace(e => e.FirstName, "Taylor");
            patchDoc.Replace(e => e.LastName, "Hill");
            patchDoc.Replace(e => e.EmailAddress, "taylor.hill@gmail.com");
            
            var updateResult = await _controller.PatchAsync(client.Id, patchDoc);
        }

        [Fact]
        public async void Can_Get_Client_All_Clients()
        {
            var getResult = await _controller.GetClientsAsync(1, 2);
            var expected = _loanDbContext.Clients.Where(c => c.RecordStatusId == LookupIds.RecordStatus.Active).Count();

            Assert.IsType<ActionResult<PagedResultDto<ClientDto>>>(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);

            var result = getResult.Result as OkObjectResult;
            var clientPagedResult = result?.Value as PagedResultDto<ClientDto>;
                        
            Assert.True(clientPagedResult.RowCount == expected);            
        }


        [Fact]        
        public async Task Can_Not_Delete_Client_With_Active_Account()
        {
            var deleteClient = _loanDbContext.Clients.First();
            _fixture.CreateAccount(deleteClient.Id);

            var deleteException = await Assert.ThrowsAsync<HttpResponseException>(() => _controller.DeleteAsync(deleteClient.Id));
            Assert.NotNull(deleteException.Value);

            var busError = deleteException.Value as BusinessValidationError;

            Assert.True(busError.ValidationErrors.Count == 1);

            var error = busError.ValidationErrors.First();
            Assert.True(error.Code == ClientValidationErrorCodes.CLIENT_HAS_AN_ACTIVE_ACCOUNT);            

        }

        [Fact]
        public async void Client_Dob_Must_Be_On_Or_After_1950()
        {
            var dob = new DateTime(1899, 12, 31);
            var client = _fixture.JohnDough;
            client.Dob = dob;
            var createException = await Assert.ThrowsAsync<HttpResponseException>(() => _controller.CreateAsync(client));

            Assert.NotNull(createException.Value);

            var busError = createException.Value as BusinessValidationError;

            Assert.True(busError.ValidationErrors.Count == 1);

            var error = busError.ValidationErrors.First();
            Assert.True(error.Code == ClientValidationErrorCodes.CLIENT_DATE_OF_BIRTH_ERROR);
        }

        [Fact]
        public async void Client_Must_Be_At_Least_18_Year_Old()
        {
            var dob = _testDateService.CurrentDate.AddYears(-17);
            var client = _fixture.JohnDough;
            client.Dob = dob;
            var createException = await Assert.ThrowsAsync<HttpResponseException>(() => _controller.CreateAsync(client));

            Assert.NotNull(createException.Value);

            var busError = createException.Value as BusinessValidationError;

            Assert.True(busError.ValidationErrors.Count == 1);

            var error = busError.ValidationErrors.First();
            Assert.True(error.Code == ClientValidationErrorCodes.CLIENT_IS_UNDER_AGE);
        }

        [Fact]
        public async void Can_Search_Client_To_All_Fields()
        {
            var searchResult = await _controller.SearchAsync("james", 1, 5);
            var expected = 3;

            Assert.IsType<ActionResult<PagedResultDto<ClientDto>>>(searchResult);
            
            var result = searchResult?.Result as OkObjectResult;
            var clientPagedResult = result?.Value as PagedResultDto<ClientDto>;            
                        
            Assert.True(clientPagedResult.RowCount == expected);
        }


    }
}