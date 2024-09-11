using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer.IReposatory
{
    public interface IAnnouncementRepository
    {
        public Task<int> CreateAnnouncement(AnnouncementDto announcement , string Role , String Id);
        public Task<String> DeleteAnnouncement(int id, string Role);
        public Task<IEnumerable<announcementModel>> GetAllAnnouncements ();

    }
}
