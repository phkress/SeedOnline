using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interface;
using Repository;
using Repository.Persistence;

namespace Repository
{
    public class ModelUOW : IModelUOW
    {
        private readonly InfTeamApiDBContext _context;

        public IProfile Profiles { get; private set; }

        public IPost Posts { get; private set; }

        public IRole Roles { get; private set; }

        public ITeam Teams { get; private set; }

        public ITodo Todos { get; private set; }

        public ModelUOW(InfTeamApiDBContext context)
        {
            _context = context;
            Profiles = new ProfileRepository(_context);
            Posts = new PostRepository(_context);
            Roles = new RoleRepository(_context);
            Teams = new TeamRepository(_context);
            Todos = new TodoRepository(_context);
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
