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
    public class MemberRepository : Repository<Member>, IMember
    {
        public MemberRepository(InfTeamApiDBContext context) :base(context)
        {
        }
    }
}
