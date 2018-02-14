using Microsoft.AspNetCore.Mvc;
using Nymity.Core.Entities;
using Nymity.Core.Repositories;

namespace Nymity.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Authenticate")]
    public class AuthenticateController : Controller
    {
        /// <summary>
        /// User repository
        /// </summary>
        private IUserRepository _userRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userRepository">User Repository.</param>
        public AuthenticateController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody]Authenticate authenticate)
        {
            var user = _userRepository.Authenticate(authenticate.Email, authenticate.Password);

            if (user == null)
                return Unauthorized();

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = 1,
                Name = "Chan Valle",
                Email = "chan@mail.com",
                Token = "token"
            });
        }
    }
}