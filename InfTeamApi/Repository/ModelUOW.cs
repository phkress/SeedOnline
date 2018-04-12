using Model.Interface;
using Repository.Persistence;

namespace Repository
{
    public class ModelUOW : IModelUOW
    {
        private readonly InfTeamApiDBContext _context;

        public IProfile Profiles { get; private set; }

        public ITeam Teams { get; private set; }

        public ModelUOW(InfTeamApiDBContext context)
        {
            _context = context;
            Profiles = new ProfileRepository(_context);
            Teams = new TeamRepository(_context);
        }        

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
