using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class ProfileSkills
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int UserId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Profile User { get; set; }
    }
}
