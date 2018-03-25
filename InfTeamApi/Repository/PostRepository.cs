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
    public class PostRepository : Repository<Post>, IPost
    {
        public PostRepository(InfTeamApiDBContext context) :base(context)
        {
        }
    }
}
