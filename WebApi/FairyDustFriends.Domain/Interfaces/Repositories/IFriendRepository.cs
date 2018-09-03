using FairyDustFriends.Domain.Entities;
using System.Collections.Generic;

namespace FairyDustFriends.Domain.Interfaces.Repositories
{
    public interface IFriendRepository
    {
        void Create(Friend Friend);
        Friend Get(string id);
        List<Friend> GetAll();
        void Delete(string id);
        void Update(Friend Friend);

    }
}
