using businessLayer.IReposatory;
using dataAccessLayer.DTO;
using dataAccessLayer.Models;
using dataAccessLayer.sealedModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer.Reposatory
{
    public class AuthenticationRepository : IAuthnticationRepostory
    {
       
        public AuthenticationRepository(MasterDbContext masterDbContext , IConfiguration configuration , Roles rule) {
            MasterDbContext = masterDbContext;
            Configuration = configuration;
            _Rule = rule;
        }

        public  MasterDbContext MasterDbContext { get; }
        public IConfiguration Configuration { get; }
        public Roles _Rule { get; }


        // we will do here jwt auth 
        public async Task<string> Signin(String UsernameOrEmail , string password)
        {
            var verifyResult = await MasterDbContext.users.Where(u => u.Name == UsernameOrEmail || u.Email == UsernameOrEmail && u.Password == password).CountAsync();
         
            if (verifyResult == 1)
            {
                var GetId= await MasterDbContext.users.Where(u => u.Name == UsernameOrEmail || u.Email == UsernameOrEmail && u.Password == password).FirstOrDefaultAsync();
             
                var GetSymmetricCode = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"]));
                var claims_ = new[] {
                new Claim(ClaimTypes.Name , GetId.Id.ToString()),
                new Claim(ClaimTypes.Role, GetId.type.ToString())

                };
               var credintial = new SigningCredentials(GetSymmetricCode,SecurityAlgorithms.HmacSha256);
            
                var MakeJwt = new JwtSecurityToken(
                    claims: claims_,
                    signingCredentials: credintial,
                    expires: DateTime.Now.AddHours(30),
                    issuer: Configuration["jwt:issuer"],
                    audience : Configuration["jwt:audiance"]

                    );

                return new JwtSecurityTokenHandler().WriteToken( MakeJwt );
                
            }
            else
            {
                return "your auth is wrong";
            }
        }

        // add user when there is no email or Name like him or it will show him 0 at result the is mean
        //it`s failed to add the user

        public async Task<int> Signup(UserSignupDto usersDto)
        {

            if (_Rule.Worker != usersDto.type || _Rule.Manager != usersDto.type || _Rule.Student != usersDto.type) {

                return 0;
                
            
            }
            var verifyResult = await MasterDbContext.users.Where(u=>u.Name == usersDto.Name ||  u.Email == usersDto.Email ).CountAsync();
            if (verifyResult == 0)
            {
                UsersModel newuser = new UsersModel
                {
                    Name = usersDto.Name,
                    Email = usersDto.Email,
                    contractId = null,
                    Password = usersDto.Password,
                    type = usersDto.type,




                };
                await MasterDbContext.users.AddAsync(newuser);
                await MasterDbContext.SaveChangesAsync();
                return 1;
            }
            else {
                return 0;
            }
        }



    }
}
