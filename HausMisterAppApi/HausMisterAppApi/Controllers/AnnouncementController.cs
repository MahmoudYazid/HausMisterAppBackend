using businessLayer.IReposatory;
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
    public class AnnouncementController : ControllerBase
    {
        public AnnouncementController(IHttpContextAccessor httpContextAccessor , IAnnouncementRepository announcementRepository )
        {
            HttpContextAccessor = httpContextAccessor;
            AnnouncementRepository = announcementRepository;
        }

        public IHttpContextAccessor HttpContextAccessor { get; }
        public IAnnouncementRepository AnnouncementRepository { get; }
        [Authorize]
        [HttpPost("CreateAnnouncement")]
        public async Task<int> CreateAnnouncement(AnnouncementDto announcementDto)
        {
            var CurrentUser = HttpContext.User.Identity as ClaimsIdentity;
            var role = CurrentUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var Id = CurrentUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var query = await  AnnouncementRepository.CreateAnnouncement(announcementDto , role , Id);
            return query;



        }
        [Authorize]
        [HttpDelete("DeleteAnnouncement/{id}")]
        public async Task<String> DeleteAnnouncement(int id)
        {
            var CurrentUser = HttpContext.User.Identity as ClaimsIdentity;
            var role = CurrentUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
 
            var query = await AnnouncementRepository.DeleteAnnouncement(id, role);
            return query;



        }
        [Authorize]

        [HttpGet("GetAllAnnouncement")]
        public async Task<IEnumerable<announcementModel>> GetAllAnnouncement()
        {
            var query = await AnnouncementRepository.GetAllAnnouncements();
            return query;



        }





    }
}
