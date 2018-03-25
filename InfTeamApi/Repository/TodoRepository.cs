using Model;
using Model.Interface;
using Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TodoRepository : Repository<Todo>, ITodo
    {
        public TodoRepository(InfTeamApiDBContext context) :base(context)
        {
        }
    }
}
