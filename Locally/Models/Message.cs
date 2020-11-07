using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class Message
    {
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        public int ServiceId { get; set; }
        public int Id { get; set; }
        public string Content { get; set; }

        public virtual Service Service { get; set; }
        public virtual User UserFromNavigation { get; set; }
        public virtual User UserToNavigation { get; set; }
    }
}
