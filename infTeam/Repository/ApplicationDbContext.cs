using Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Server=tcp:infteamserver.database.windows.net,1433;Initial Catalog=infteamdb;Persist Security Info=False;User ID=loginqualquer;Password=@Emp77777;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
