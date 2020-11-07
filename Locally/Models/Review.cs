using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class Review
    {
        public Review()
        {
            PhotosReview = new HashSet<PhotosReview>();
            Service = new HashSet<Service>();
        }

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PhotosReview> PhotosReview { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}
