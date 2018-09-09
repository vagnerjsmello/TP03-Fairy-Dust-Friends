using FairyDustFriends.Domain.Adapters;
using FairyDustFriends.Domain.Interfaces.Repositories;
using FairyDustFriends.Domain.Interfaces.Services;
using FairyDustFriends.Domain.ViewModels;
using System.Collections.Generic;

namespace FairyDustFriends.Domain
{
    public class FriendService : IFriendService
    {
        private IFriendRepository _friendRepository;

        public FriendService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public void Add(FriendViewModel viewModel)
        {
            var friend = new FriendAdapter().ViewModelToFriend(viewModel);

            _friendRepository.Create(friend);
        }

        public void Delete(string id)
        {
            _friendRepository.Delete(id);
        }

        public FriendViewModel Get(string id)
        {
            var friend = _friendRepository.Get(id);
                
            var viewModel = new FriendAdapter().FriendToViewModel(friend);

            return viewModel;
        }

        public List<FriendViewModel> GetAll()
        {
            var friendsViewModel = new List<FriendViewModel>();
            var friends = _friendRepository.GetAll();

            foreach (var Friend in friends)
            {
                friendsViewModel.Add(new FriendAdapter().FriendToViewModel(Friend));
            }

            return friendsViewModel;
        }

        public void Update(FriendViewModel viewModel)
        {
            var friend = new FriendAdapter().ViewModelToFriend(viewModel);

            _friendRepository.Update(friend);
        }
    }
}
