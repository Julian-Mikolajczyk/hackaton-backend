using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class PhotosService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int PhotoId { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual Service Service { get; set; }
    }
}
