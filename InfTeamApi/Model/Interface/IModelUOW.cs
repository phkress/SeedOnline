using System;

namespace Model.Interface
{
    public interface IModelUOW : IDisposable
    {
        IProfile Profiles { get; }

        ITeam Teams { get; }

        int Complete();
    }
}
