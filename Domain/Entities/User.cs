using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notification.Domain.Entities
{
    public class User
    {
        public User()
        {
            Users = new HashSet<User>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Retries { get; set; }
        public bool IsVerified { get; set; }

        [NotMapped]
        public ICollection<User> Users { get; private set; }

    }

}
