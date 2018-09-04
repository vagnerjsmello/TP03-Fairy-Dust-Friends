using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FairyDustFriends.WebApp.Models
{
    public class FriendModel
    {
        public String Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail invalid!")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [StringLength(maximumLength:14, MinimumLength =8)]        
        public String Phone { get; set; }

        [Required]
        [Display(Name = "Birthday")]        
        public String Birthday { get; set; }
    }
}