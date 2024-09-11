using businessLayer.IReposatory;
using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using dataAccessLayer.sealedModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer.Reposatory
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        public AnnouncementRepository ( MasterDbContext masterDbContext , Roles roles ) {
            MasterDbContext = masterDbContext;
            
            Roles = roles;
        }

        public MasterDbContext MasterDbContext { get; }

        public Roles Roles { get; }

        public async Task<int> CreateAnnouncement(AnnouncementDto announcement , string Role , String Id)

        {
           
            if (Role == Roles.Manager)
            {

               

                var newAnnounce = new announcementModel { Details = announcement.Details, publicherId = Convert.ToInt32(Id) };
                await MasterDbContext.announcements.AddAsync(newAnnounce);
                await MasterDbContext.SaveChangesAsync();
                return 1;
            }
            else
            {

                return 0;
            }
            
          
      
            
        }

        public async Task<String> DeleteAnnouncement(int id,string rule)
        {
        
            if (rule == Roles.Manager)
            {
                var GetObj =  MasterDbContext.announcements.Find(id);
                if (GetObj != null)
                {
                    MasterDbContext.announcements.Remove(GetObj);
                    await MasterDbContext.SaveChangesAsync();
                    return $"Announcement {id} has been deleted";
                }
                else
                {
                    return "we coundn`t find the obj";
                }
            }
            else
            {

                return " you do not have authuntication to do this";
            }
        }



        public async Task<IEnumerable<announcementModel>> GetAllAnnouncements()
        {
            var result = await MasterDbContext.announcements .ToListAsync();
            return result;
        }
    }
}
