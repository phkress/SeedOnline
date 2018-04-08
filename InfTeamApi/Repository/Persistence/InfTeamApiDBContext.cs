using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace Repository.Persistence
{
    public class InfTeamApiDBContext : DbContext
    {
        public InfTeamApiDBContext() : base("Server = tcp:infteamserver.database.windows.net, 1433; Initial Catalog = infteamdb; Persist Security Info=False;User ID =loginqualquer; Password=@Emp77777; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;")
        {
           Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Menssage> Menssages { get; set; }
    }
}
