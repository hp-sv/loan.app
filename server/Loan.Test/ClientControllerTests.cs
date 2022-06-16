using Loan.Interface.Domain;
using Loan.Interface.Repositories;
using Loan.Interface.Services;
using Loan.Repository;
using Loan.Domain;
using Loan.Api.Controllers;
using Loan.Domain.Services;
using Loan.Model.Client;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Loan.Interface.Constants;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;

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

        private readonly LoanSeedDataFixture _fixture;

        public ClientControllerTests(LoanSeedDataFixture fixture)
        {
            _fixture = fixture;
            _mapper = fixture.Mapper;
            _testDateService = fixture.DateService;
            _repository = new ClientRepository(_fixture.DbContext, _mapper);
            _accountRepository = new AccountRepository(_fixture.DbContext, _mapper);
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

           Assert.IsType<NoContentResult>(updateResult);
        }

        [Fact]
        public async Task Can_Delete_Client()
        {
            var deleteClient = _fixture.DbContext.Clients.First();
            var deleteResult = await _controller.DeleteAsync(deleteClient.Id);

            Assert.IsType<NoContentResult>(deleteResult);

            var deletedClient = _fixture.DbContext.Clients.Where(c=>c.Id == deleteClient.Id).FirstOrDefault();
            Assert.Null(deletedClient);

        }

        [Fact]
        public async void Can_Patch_Client()
        {   
            var patchDoc = new JsonPatchDocument<UpdateClientDto>();
            var client = _fixture.DbContext.Clients.First();

            patchDoc.Replace(e => e.FirstName, "Taylor");
            patchDoc.Replace(e => e.LastName, "Hill");
            patchDoc.Replace(e => e.EmailAddress, "taylor.hill@gmail.com");
            
            var updateResult = await _controller.PatchAsync(client.Id, patchDoc);
        }

        [Fact]
        public async void Can_Get_Client_All_Clients()
        {
            var getResult = await _controller.GetClientsAsync();
            var expected = _fixture.DbContext.Clients.Where(c => c.RecordStatusId == LookupIds.RecordStatus.Active).Count();

            Assert.IsType<ActionResult<IEnumerable<ClientDto>>>(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);

            var result = getResult.Result as OkObjectResult;
            var clients = result?.Value as IEnumerable<ClientDto>;
            Assert.NotNull(clients);
            Assert.True(clients?.Count() == expected);            
        }


        [Fact]
        public async void Can_Not_Delete_Client_With_Active_Account()
        {
            Assert.True(false);
        }

        [Fact]
        public async void Client_Dob_Must_Be_On_Or_After_1960()
        {
            Assert.True(false);
        }

        [Fact]
        public async void Client_Must_Be_At_Least_18_Year_Old()
        {
            Assert.True(false);
        }


    }
}