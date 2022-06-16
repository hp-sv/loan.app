using AutoMapper;
using Loan.Data.Configuration;
using Loan.Data.Context;
using Loan.Domain.Services;
using Loan.Entity;
using Loan.Interface.Constants;
using Loan.Interface.Services;
using Loan.Model.Client;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Loan.Test
{
    public class LoanSeedDataFixture : IDisposable
    {
        public IChangeTransactionScope ChangeTransactionScope { get; private set;}
        public IChangeTransactionService ChangeTransactionService { get; private set;}
        public IMapper Mapper { get; private set;}

        internal TestDateService DateService { get; private set;}

        public LoanDbContext DbContext { get; private set; }        
        private IChangeTransactionScope GetChangeTransactionScope()
        {            
            var mockCTS = new Mock<IChangeTransactionScope>();
            mockCTS.Setup(cs => cs.TransactionPath).Returns("");
            mockCTS.Setup(cs => cs.CurrentUser).Returns("test:user");
            mockCTS.Setup(cs => cs.TransactionDate).Returns(DateService.CurrentDate);
            mockCTS.Setup(cs => cs.TransactionId).Returns(Guid.NewGuid);
            return mockCTS.Object;         
        }

        public LoanSeedDataFixture()
        {
            DateService = new TestDateService(new DateTime(2022, 06, 01, 08, 0, 0));

            ChangeTransactionScope = GetChangeTransactionScope();

            var options = new DbContextOptionsBuilder<LoanDbContext>()
               .UseInMemoryDatabase(databaseName: "Loan")
               .EnableSensitiveDataLogging()
               .Options;

            DbContext = new LoanDbContext(options, ChangeTransactionScope);

            var taskLookup = configureLookup();
            taskLookup.Wait();

            var taskClient = seedClient();
            taskClient.Wait();

            var taskAccount = seedAccount();
            taskAccount.Wait();

            var config = new MapperConfiguration(opts => opts.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));
            Mapper = config.CreateMapper();

            ChangeTransactionService = new ChangeTransactionService(DbContext, ChangeTransactionScope);

        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }

        private async Task configureLookup()
        {
            var lookupSets = new LookupSetConfiguration().GetLookupSets();
            DbContext.LookupSets.AddRange(lookupSets);

            var lookupConfig = new LookupConfiguration();
            DbContext.Lookups.AddRange(lookupConfig.GetTransactionTypes());
            DbContext.Lookups.AddRange(lookupConfig.GetDurationTypes());
            DbContext.Lookups.AddRange(lookupConfig.GetRepaymentSchedule());
            DbContext.Lookups.AddRange(lookupConfig.GetRecordStatus());
            DbContext.Lookups.AddRange(lookupConfig.GetSeedConstants());
            DbContext.Lookups.AddRange(lookupConfig.GetChangeOperations());
            DbContext.Lookups.AddRange(lookupConfig.GetAccountStatuses());
            await DbContext.SaveChangesAsync();
        }

        private async Task seedClient()
        {
            var seedClients = new List<Client>
            {
                new Client("James", "Boags")
                {
                    MiddleName = "",
                    Dob = new DateTime(1960, 01, 01),
                    EmailAddress = "james.boags@gmail.com",
                    MobileNumber = "125425212",
                    AddressLine1 = "88 Wells st",
                    AddressLine2 = "",
                    AddressLine3 = "Southbank Vic 3006"
                },
                new Client("Johny", "Good")
                {
                    MiddleName = "B",
                    Dob = new DateTime(1961, 02, 01),
                    EmailAddress = "johnybgood@gmail.com",
                    MobileNumber = "125425212",
                    AddressLine1 = "76 Nguyen st",
                    AddressLine2 = "",
                    AddressLine3 = "Southbank Vic 3006"
                },
                new Client("Major", "Seventh")
                {
                    MiddleName = "",
                    Dob = new DateTime(1961, 02, 01),
                    EmailAddress = "major.seventh@gmail.com",
                    MobileNumber = "125425212",
                    AddressLine1 = "76 Nguyen st",
                    AddressLine2 = "",
                    AddressLine3 = "Southbank Vic 3006"
                },
                new Client("Minor", "Third")
                {
                    MiddleName = "",
                    Dob = new DateTime(1961, 02, 01),
                    EmailAddress = "minor.third@gmail.com",
                    MobileNumber = "125425212",
                    AddressLine1 = "76 Nguyen st",
                    AddressLine2 = "",
                    AddressLine3 = "Southbank Vic 3006"
                }
            };

            DbContext.Clients.AddRange(seedClients);
            await DbContext.SaveChangesAsync();
        }

        private async Task seedAccount()
        { 
            var client = await DbContext.Clients.FirstAsync();
            
            var account = new Account { 
            ClientId = client.Id,
            Duration = 26,
            DurationTypeId = LookupIds.DurationType.Weekly,
            Rate = 0.010m,
            RepaymentTypeId = LookupIds.RepaymentSchedule.Weekly,
            StatusId = LookupIds.AccountStatuses.Active,
            TotalAmount = 50000
            };

            DbContext.Accounts.Add(account);
            await DbContext.SaveChangesAsync();
        }

        public CreateClientDto JohnDough
        {
            get
            {
                return new CreateClientDto
                {
                    FirstName = "John",
                    MiddleName = "D",
                    LastName = "Dough",
                    Dob = new DateTime(1960, 01, 01),
                    EmailAddress = "john.dough@gmail.com",
                    MobileNumber = "125425212",
                    AddressLine1 = "88 Wells st",
                    AddressLine2 = "",
                    AddressLine3 = "Southbank Vic 3006"
                };
            }
        }

    }
}
