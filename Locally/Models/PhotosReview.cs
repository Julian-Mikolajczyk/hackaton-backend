using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class PhotosReview
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public int ReviewId { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual Review Review { get; set; }
    }
}
