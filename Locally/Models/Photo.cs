using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class Photo
    {
        public Photo()
        {
            PhotosReview = new HashSet<PhotosReview>();
            PhotosService = new HashSet<PhotosService>();
            Profile = new HashSet<Profile>();
        }

        public int Id { get; set; }
        public string Path { get; set; }

        public virtual ICollection<PhotosReview> PhotosReview { get; set; }
        public virtual ICollection<PhotosService> PhotosService { get; set; }
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
