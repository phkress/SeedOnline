using System;

namespace Model.Interface
{
    public interface IProfile : IRepository<Profile>
    {
        Profile Get(String id);
    }
}
