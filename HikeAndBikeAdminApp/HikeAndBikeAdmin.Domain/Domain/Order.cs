using HikeAndBikeAdmin.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBikeAdmin.Domain.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public HikeAndBikeUser User { get; set; }
        public ICollection<TrailInOrder> TrailInOrders { get; set; }
    }
}
