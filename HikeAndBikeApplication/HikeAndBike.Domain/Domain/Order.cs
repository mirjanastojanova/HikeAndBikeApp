using HikeAndBike.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public HikeAndBikeApplicationUser User { get; set; }
        public virtual ICollection<TrailInOrder> TrailInOrders { get; set; }
    }
}
