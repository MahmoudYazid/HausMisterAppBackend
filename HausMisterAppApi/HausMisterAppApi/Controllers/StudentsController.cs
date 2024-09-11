using businessLayer.IReposatory;
using businessLayer.Reposatory;
using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HausMisterAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public StudentsController ( IStudents StudentsRrpository) {
        
            this.StudentsRrpository = StudentsRrpository;
        }

       
        public IStudents StudentsRrpository { get; }

        [HttpPost("makeComplain")]
        [Authorize]
        public async Task<String> MakeComplain(ComplainDto complainDto) {
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var Id = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var Query = await StudentsRrpository.MakeComplain(complainDto, Id, role);
            return  Query;
        }



        [HttpPost("ShowStudentContract")]
        [Authorize]
        public async Task<UsersModel?> ShowContract()
        {
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var Id = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var Query = await StudentsRrpository.ShowContract(Convert.ToInt32(Id),role);
            return Query;
        }
    }
}
