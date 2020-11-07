using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class ServiceSkills
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
