using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer.IReposatory
{
    public interface IAuthnticationRepostory
    {

        public Task<int> Signup(UserSignupDto usersDto);
        public Task<string> Signin(String UsernameOrEmail, string password);

    }
}
