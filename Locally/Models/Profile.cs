using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class Profile
    {
        public Profile()
        {
            ProfileSkills = new HashSet<ProfileSkills>();
        }

        public int UserId { get; set; }
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProfileSkills> ProfileSkills { get; set; }
    }
}
