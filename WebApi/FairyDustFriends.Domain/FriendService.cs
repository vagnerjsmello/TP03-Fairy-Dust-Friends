using FairyDustFriends.Domain.Adapters;
using FairyDustFriends.Domain.Interfaces.Repositories;
using FairyDustFriends.Domain.Interfaces.Services;
using FairyDustFriends.Domain.ViewModels;
using System.Collections.Generic;

namespace FairyDustFriends.Domain
{
    public class FriendService : IFriendService
    {
        private IFriendRepository _FriendRepository;

        public FriendService(IFriendRepository FriendRepository)
        {
            _FriendRepository = FriendRepository;
        }
        public void Add(FriendViewModel viewModel)
        {
            var Friend = new FriendAdapter().ViewModelToFriend(viewModel);

            _FriendRepository.Create(Friend);
        }

        public void Delete(string id)
        {
            _FriendRepository.Delete(id);
        }

        public FriendViewModel Get(string id)
        {
            var Friend = _FriendRepository.Get(id);
                
            var viewModel = new FriendAdapter().FriendToViewModel(Friend);

            return viewModel;
        }

        public List<FriendViewModel> GetAll()
        {
            var FriendsViewModel = new List<FriendViewModel>();
            var Friends = _FriendRepository.GetAll();

            foreach (var Friend in Friends)
            {
                FriendsViewModel.Add(new FriendAdapter().FriendToViewModel(Friend));
            }

            return FriendsViewModel;
        }

        public void Update(FriendViewModel viewModel)
        {
            var Friend = new FriendAdapter().ViewModelToFriend(viewModel);

            _FriendRepository.Update(Friend);
        }
    }
}
