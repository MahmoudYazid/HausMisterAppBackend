using businessLayer.IReposatory;
using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HausMisterAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController( IAuthnticationRepostory authnticationRepostoryImplement) {
            AuthnticationRepostoryImplement = authnticationRepostoryImplement;
        }

        public IAuthnticationRepostory AuthnticationRepostoryImplement { get; }

        [HttpPost("Signin")]
        public async Task<string> Login ([FromBody] LogInDto logInDto) => await AuthnticationRepostoryImplement.Signin(logInDto.userName, logInDto.password);

        [HttpPost("SignUp")]
        public async Task<int> Signup ([FromBody]UserSignupDto usersModelDto) => await AuthnticationRepostoryImplement.Signup (usersModelDto);


    }
}
