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

        IPost Posts { get; }

        ITeam Teams { get; }

        int Complete();
    }
}
