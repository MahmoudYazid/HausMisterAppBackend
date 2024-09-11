using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccessLayer.Models
{
    public class MasterDbContext:DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {
        }

        public DbSet<ComplainsModel> Complains { get; set; }
        public DbSet<ContractModel> Contracts { get; set; }
        public DbSet<UsersModel> users { get; set; }
        public DbSet<announcementModel> announcements { get; set; }

    }
}
