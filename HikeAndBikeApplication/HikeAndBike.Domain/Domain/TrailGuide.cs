using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikeAndBike.Domain.Domain
{
    public class TrailGuide : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string MountaineeringClub { get; set; }
        public virtual ICollection<GuideForTrail> GuideForTrails { get; set; }
    }
}
