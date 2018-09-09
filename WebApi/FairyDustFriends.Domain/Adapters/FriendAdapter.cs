using FairyDustFriends.Domain.Entities;
using FairyDustFriends.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyDustFriends.Domain.Adapters
{
    public class FriendAdapter
    {
        public Friend ViewModelToFriend(FriendViewModel viewModel)
        {
            return new Friend(
                Guid.Parse(viewModel.Id),
                viewModel.FirstName,
                viewModel.LastName,
                viewModel.Email,
                viewModel.Phone,
                DateTime.Parse(String.Format("{0:MM/dd/yyyy}", viewModel.Birthday))
            );
        }

        public FriendViewModel FriendToViewModel(Friend friend)
        {
            return new FriendViewModel()
            {
                Id = friend.Id.ToString(),
                FirstName = friend.FirstName,
                LastName = friend.LastName,
                Email = friend.Email,
                Phone = friend.Phone,
                Birthday = friend.Birthday.ToString()
            };
        }
    }
}
