using Loan.Interface.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Loan.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public class AuthenticationRequestBody
        {            
            public string? UserName { get; set; }
            public string? Password { get; set; }

        }

        public class LoanUserInfo
        {
            public int UserId { get; set; }
            public string UserName { get; set; }    
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public LoanUserInfo(
                    int userId, 
                    string userName, 
                    string firstName, 
                    string lastName)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
            }
        }

        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost]
        public ActionResult<string> Authenticate( AuthenticationRequestBody authenticationRequestBody)
        {
            // 1) Validate the user credential
            var user = ValidateUserCredential(
                authenticationRequestBody.UserName, 
                authenticationRequestBody.Password);

            if (user == null)
                return Unauthorized();

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration[ConfigurationKey.AuthenticationSecretForKey])
                ) ;
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>()
            {
                new Claim("sub", user.UserId.ToString()),
                new Claim("given_name", user.FirstName),
                new Claim("family_name", user.LastName)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration[ConfigurationKey.AuthenticationIssuer],
                _configuration[ConfigurationKey.AuthenticationAudience],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private LoanUserInfo ValidateUserCredential(string? userName, string? password)
        {
            // Dummy user only
            return new LoanUserInfo( 123, "john.dough", "John", "Douhg" );
        }
    }
}
