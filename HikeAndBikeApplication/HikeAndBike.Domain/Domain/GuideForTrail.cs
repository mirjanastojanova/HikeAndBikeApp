using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Domain.Domain
{
    public class GuideForTrail
    {
        public Guid TrailId { get; set; }
        public Trail Trail { get; set; }
        public Guid TrailGuideId { get; set; }
        public TrailGuide TrailGuide { get; set; }
    }
}
