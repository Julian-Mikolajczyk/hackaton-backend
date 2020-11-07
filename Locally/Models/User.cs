using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class User
    {
        public User()
        {
            MessageUserFromNavigation = new HashSet<Message>();
            MessageUserToNavigation = new HashSet<Message>();
            Review = new HashSet<Review>();
            ServicePreApprovedUser = new HashSet<Service>();
            ServiceUserContractorNavigation = new HashSet<Service>();
            ServiceUserOwnerNavigation = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Message> MessageUserFromNavigation { get; set; }
        public virtual ICollection<Message> MessageUserToNavigation { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Service> ServicePreApprovedUser { get; set; }
        public virtual ICollection<Service> ServiceUserContractorNavigation { get; set; }
        public virtual ICollection<Service> ServiceUserOwnerNavigation { get; set; }
    }
}
