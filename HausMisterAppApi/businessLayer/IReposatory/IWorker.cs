using dataAccessLayer.DTO;
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

    }
}
