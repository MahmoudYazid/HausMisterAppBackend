using businessLayer.IReposatory;
using dataAccessLayer.DTO;

using dataAccessLayer.Models;
using dataAccessLayer.sealedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer.Reposatory
{
    public class StudentsRepository : IStudents
    {
        public StudentsRepository( MasterDbContext masterDbContext , Roles roles , ComplainsStatus complainsStatus) {
            MasterDbContext = masterDbContext;
            Roles = roles;
            ComplainsStatus = complainsStatus;
        }

        public MasterDbContext MasterDbContext { get; }
        public Roles Roles { get; }
        public ComplainsStatus ComplainsStatus { get; }

        public async Task<string> MakeComplain(ComplainDto complainDto, String StudentId, string TypeOfUser )
        {

            if (TypeOfUser.ToString() == Roles.Student.ToString()) {
                var NewComplain = new ComplainsModel
                {

                    StudentId = Convert.ToInt32(StudentId),
                    answeredBy = null,
                    Details = complainDto.Details,
                    response = "",
                    status = ComplainsStatus.Inprocess,
                    ManagerId = null,



                };
                await MasterDbContext.Complains.AddAsync(NewComplain);
                MasterDbContext.SaveChangesAsync();
                return "complain has been added"; 
            }
            else {

                return "No one can make complain except students";
            }
            
            
        }

        public async Task<UsersModel?> ShowContract(int StudentId, string TypeOfUser)
        {
            if (TypeOfUser.ToString() == Roles.Student.ToString())
            {
                var result = MasterDbContext.users.Where(joined => joined.Id== StudentId).FirstOrDefault();

                return result;



            }
            else {

                return null;
            
            
            }

        }


    }
}
