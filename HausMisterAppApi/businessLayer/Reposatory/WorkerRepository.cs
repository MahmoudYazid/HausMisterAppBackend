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
        public WorkerRepository(MasterDbContext masterDbContext , Roles roles ) {
            MasterDbContext = masterDbContext;
            Roles = roles;
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
    }
}
