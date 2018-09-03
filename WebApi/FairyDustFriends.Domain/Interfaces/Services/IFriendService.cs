using FairyDustFriends.Domain.ViewModels;
using System.Collections.Generic;

namespace FairyDustFriends.Domain.Interfaces.Services
{
    public interface IFriendService
    {
        void Add(FriendViewModel Friend);
        FriendViewModel Get(string id);
        List<FriendViewModel> GetAll();
        void Delete(string id);
        void Update(FriendViewModel Friend);
    }
}
