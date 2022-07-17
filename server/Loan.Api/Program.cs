
using Loan.Api.Filters;
using Loan.Api.Service;
using Loan.Data.Context;
using Loan.Domain;
using Loan.Domain.Services;
using Loan.Interface.Constants;
using Loan.Interface.Domain;
using Loan.Interface.Repositories;
using Loan.Interface.Services;
using Loan.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

const string ALLOWED_CORS_POLICY = "CORS_ALLOWED_ORIGIN_POLICY";

builder.Services.AddCors(options =>
{
    options.AddPolicy( name: ALLOWED_CORS_POLICY,
                    policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                      });
});


// Add services to the container.
builder.Services.AddControllers(options => {    
    options.ReturnHttpNotAcceptable = true;
    options.Filters.Add<HttpResponseExceptionFilter>();        
}).AddJsonOptions(options=>
    {        
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

    })
  .AddXmlDataContractSerializerFormatters();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<LoanDbContext>(
    dbContextOptions =>    
        dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:Loan.Database"], sqlServerOptionsAction : options => options.EnableRetryOnFailure() )
        .EnableSensitiveDataLogging()
);

builder.Services.AddScoped<IDateService, DateService>();
builder.Services.AddScoped<IChangeTransactionScope, LoanTransactionScope>();
builder.Services.AddScoped<IChangeTransactionService, ChangeTransactionService>();
builder.Services.AddScoped<IAccountTransactionGeneratorService, AccountTransactionGeneratorService>();

builder.Services.AddScoped<IClientValidationService, ClientValidationService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientDomain, ClientDomain>();

builder.Services.AddScoped<ILookupSetRepository, LookupSetRepository>();
builder.Services.AddScoped<ILookupSetDomain, LookupSetDomain>();

builder.Services.AddScoped<IAccountValidationService, AccountValidationService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountDomain, AccountDomain>();

builder.Services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
builder.Services.AddScoped<IAccountCommentRepository, AccountCommentRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration[ConfigurationKey.AuthenticationIssuer],
            ValidAudience = builder.Configuration[ConfigurationKey.AuthenticationAudience],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration[ConfigurationKey.AuthenticationSecretForKey]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(ALLOWED_CORS_POLICY);

app.UseAuthentication();   
app.UseAuthorization();



app.UseEndpoints(enpoints =>
{
    enpoints.MapControllers();
});

app.Run();
