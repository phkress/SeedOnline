using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IModelUOW : IDisposable
    {
        IProfile Profiles { get; }

        IMember Members { get; }

        IPost Posts { get; }

        IRole Roles { get; }

        ITeam Teams { get; }

        ITodo Todos { get; }

        int Complete();
    }
}
