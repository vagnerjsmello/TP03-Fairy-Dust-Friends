
using System;
using System.ComponentModel.DataAnnotations;

namespace FairyDustFriends.Domain.ViewModels
{
    public class FriendViewModel
    {        
        public String Id { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }
        [Required]
        public String Birthday { get; set; }
    }
}
