using businessLayer.IReposatory;
using dataAccessLayer.DTO;
using dataAccessLayer.Models;
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

        [HttpDelete("DeleteContract/{id}")]
        [Authorize]
        public async Task<String> DeleteContract(int id)
        {
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
          

            var result = await Worker.DeleteContract(id, role);
            return result;

        }
        [HttpGet("ShowAllTheComplains")]
        [Authorize]
        public  async Task<IEnumerable<ComplainsModel>?> ShowAllTheComplains()
        {
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var result = await Worker.ShowAllComplains(role);



            return result ;

        }

        [HttpPost("ModifyComplainsStatus")]
        [Authorize]
        public async Task<String?> ModifyComplainsStatus(int CompalinID, string NewStatus )
        {
           
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var WorkerOrMangerId = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var result = await Worker.ChangeComplainsState(CompalinID,NewStatus, Convert.ToInt32(WorkerOrMangerId));



            return result;

        }


        [HttpPost("AddCommentToTheComplains")]
        [Authorize]
        public async Task<String?> AddCommentToTheComplains( int CompalinID, string Comment)
        {
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var WorkerOrMangerId = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var result = await Worker.AddCommentToTheComplains(CompalinID, Comment, Convert.ToInt32(WorkerOrMangerId));



            return result;

        }

        [HttpDelete("DeleteComplains/{id}")]
        [Authorize]
        public async Task<String> DeleteComplains(int id)
        {
            var UserData = HttpContext.User.Identity as ClaimsIdentity;
            var role = UserData.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;


            var result = await Worker.DeleteComplains(id, role);
            return result;

        }

    }
}
