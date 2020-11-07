using System;
using System.Collections.Generic;

namespace Locally.Models
{
    public partial class Service
    {
        public Service()
        {
            Message = new HashSet<Message>();
            PhotosService = new HashSet<PhotosService>();
            ServiceSkills = new HashSet<ServiceSkills>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public float LocationX { get; set; }
        public float LocationY { get; set; }
        public int Price { get; set; }
        public int UserOwner { get; set; }
        public int? UserContractor { get; set; }
        public int? ReviewId { get; set; }
        public int? PreApprovedUserId { get; set; }

        public virtual User PreApprovedUser { get; set; }
        public virtual Review Review { get; set; }
        public virtual User UserContractorNavigation { get; set; }
        public virtual User UserOwnerNavigation { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<PhotosService> PhotosService { get; set; }
        public virtual ICollection<ServiceSkills> ServiceSkills { get; set; }
    }
}
