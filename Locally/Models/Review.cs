using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class Review
    {
        public Review()
        {
            PhotosReview = new HashSet<PhotosReview>();
        }

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PhotosReview> PhotosReview { get; set; }
    }
}
