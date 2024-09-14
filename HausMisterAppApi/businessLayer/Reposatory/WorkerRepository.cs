using businessLayer.IReposatory;
using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using dataAccessLayer.sealedModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer.Reposatory
{
    public class WorkerRepository : IWorker
    {
        private readonly ComplainsStatus complainsStatus;

        public WorkerRepository(MasterDbContext masterDbContext , Roles roles , ComplainsStatus _complainsStatus) {
            MasterDbContext = masterDbContext;
            Roles = roles;
            complainsStatus = _complainsStatus;
        }

        public MasterDbContext MasterDbContext { get; }
        public Roles Roles { get; }

        public async Task<string> DeleteContract(int ContractId, string RuleOfUser)
        {
            if (RuleOfUser == Roles.Worker || RuleOfUser == Roles.Manager) {
                var GetObj = await MasterDbContext.Contracts.FindAsync(ContractId);
                MasterDbContext.Contracts.Remove(GetObj);
                await MasterDbContext.SaveChangesAsync();

                return $"Object id number {ContractId} has been removed";
            }
            else
            {

                return "you do not have auth. to remove the contract";

            }
        }

        public  async Task<string> MakeContract(ContractDto _contractDto , string RuleOfUser)
        {

            if (RuleOfUser == Roles.Worker || RuleOfUser == Roles.Manager)
            {

                var GetContractOfStudent = await MasterDbContext.users.FindAsync(_contractDto.StudentId);

                if (GetContractOfStudent == null) {

                    return "this student not exist"; 
                }

                // check if student has already a contract
                if (GetContractOfStudent.contractId == null)
                {

                    var NewContract = new ContractModel
                    {
                        details = _contractDto.details,
                        Flat_no = _contractDto.Flat_no,
                        time_start_contract = _contractDto.time_start_contract,
                        time_end_contract = _contractDto.time_end_contract,




                    };
                    await MasterDbContext.Contracts.AddAsync(NewContract);

                    await MasterDbContext.SaveChangesAsync();

                    // update student contract field


                    var IdOfStudent = await MasterDbContext.users.FindAsync(_contractDto.StudentId);

                    var GetIdOfContract = await MasterDbContext.Contracts.Where(x => x.Flat_no == _contractDto.Flat_no).FirstOrDefaultAsync();
                    IdOfStudent.contractId = GetIdOfContract.Id;

                    await MasterDbContext.SaveChangesAsync();

                    return "contract done";
                }
                else
                {
                    return "this student has contract before";
                }


            }
            else {

                return "You do not have authority to do a contract";
            
            }
            // make contract

        }

        public async Task<String? > AddCommentToTheComplains(int ComplainId, string Comment,int WorkerID)
        {
            var findid_ = await MasterDbContext.Complains.FindAsync(ComplainId);
            if (findid_ != null) {
                findid_.response = Comment;
                findid_.ManagerId = WorkerID;

                await MasterDbContext.SaveChangesAsync();
                return $"COMMENT ADDED TO ComplainID {ComplainId}";


            }
            else { return null ; }
        }

        public async Task<String?> ChangeComplainsState(int ComplainId, string newStatus, int WorkerID)
        {
            if (newStatus.ToString() != complainsStatus.Inprocess.ToString() && newStatus.ToString() != complainsStatus.rejected.ToString() && newStatus.ToString() != complainsStatus.Done.ToString()) {
                return $"Status Should be {complainsStatus.Inprocess},{complainsStatus.Done},{complainsStatus.rejected}";
            }
            else
            {
                var findid_ = await MasterDbContext.Complains.FindAsync(ComplainId);
                if (findid_ != null)
                {
                    findid_.status = newStatus;
                    findid_.ManagerId = WorkerID;

                    await MasterDbContext.SaveChangesAsync();
                    return $"Status Modified TO ComplainID {ComplainId}";


                }
                else { return null; }
            }
          
        }

        public  async Task<IEnumerable<ComplainsModel>?> ShowAllComplains(string RuleOfUser)
        {
            if(RuleOfUser == Roles.Worker || RuleOfUser == Roles.Manager) { 
                return await MasterDbContext.Complains.ToListAsync();
            }
            else
            {
                return null;

            }
        }

        public async Task<String?> DeleteComplains(int ComplainId, string RuleOfUser)
        {
            if (RuleOfUser == Roles.Worker || RuleOfUser == Roles.Manager)
            {
                var findId = await MasterDbContext.Complains.FindAsync(ComplainId);
                MasterDbContext.Complains.Remove(findId);
                await MasterDbContext.SaveChangesAsync();
                return $"Complain id: {ComplainId} has been deleted";
            }
            else
            {
                return null;

            }
        }
    }
}
