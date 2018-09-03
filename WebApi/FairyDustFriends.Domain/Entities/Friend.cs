using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyDustFriends.Domain.Entities
{
    public class Friend
    {
        public Guid Id { get; private set; }
        public String FirstName { get; private set; }
        public String LastName { get; private set; }
        public String Email { get; private set; }
        public String Phone { get; private set; }
        public DateTime Birthday { get; private set; }

        public Friend(Guid id, string first, string last, string email, string phone, DateTime birthday)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            Email = email;
            Phone = phone;
            Birthday = birthday;
        }      

    }
}