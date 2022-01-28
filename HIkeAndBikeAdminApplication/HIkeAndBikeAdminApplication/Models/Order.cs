using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIkeAndBikeAdminApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public HikeAndBikeApplicationUser User { get; set; }
        public ICollection<TrailInOrder> TrailInOrders { get; set; }
    }
}
