using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer.DTO;

using dataAccessLayer.Models;
namespace businessLayer.IReposatory
{
    public interface IStudents
    {
        public  Task<string>  MakeComplain(ComplainDto complainDto ,String StudentId , string TypeOfUser);
        public Task<UsersModel?> ShowContract(int StudentId, string TypeOfUser);
        
    }
}
