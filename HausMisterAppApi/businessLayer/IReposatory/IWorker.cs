using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer.IReposatory
{
    public interface IWorker
    {
        public Task<string> MakeContract(ContractDto _contractDto, string RuleOfUser);
        public Task<string> DeleteContract(int ContractId, string RuleOfUser);
        public  Task<String?> AddCommentToTheComplains(int ComplainId, string Comment, int WorkerID);
        public Task<String?> ChangeComplainsState(int ComplainId, string newStatus, int WorkerID);
        public Task<String?> DeleteComplains(int ComplainId, string RuleOfUser);
        public Task<IEnumerable<ComplainsModel>?> ShowAllComplains(string RuleOfUser);

    }
}
