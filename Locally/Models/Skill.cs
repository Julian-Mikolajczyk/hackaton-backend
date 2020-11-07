using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class Skill
    {
        public Skill()
        {
            ProfileSkills = new HashSet<ProfileSkills>();
            ServiceSkills = new HashSet<ServiceSkills>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProfileSkills> ProfileSkills { get; set; }
        public virtual ICollection<ServiceSkills> ServiceSkills { get; set; }
    }
}
