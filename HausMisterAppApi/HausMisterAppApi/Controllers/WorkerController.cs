using businessLayer.IReposatory;
using dataAccessLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Security.Claims;

namespace HausMisterAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {

        public WorkerController( IWorker worker) {
            Worker = worker;
        }

        public IWorker Worker { get; }

        [HttpPost("MakeContract")]
        [Authorize]
        public async Task<String> MakeContract(ContractDto _contractDto)
        {
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var WorkerOrMangerId = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

            var result = await Worker.MakeContract(_contractDto, role);
            return result;

        }

        [HttpPost("DeleteContract/{id}")]
        [Authorize]
        public async Task<String> DeleteContract(int id)
        {
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
          

            var result = await Worker.DeleteContract(id, role);
            return result;

        }

    }
}
