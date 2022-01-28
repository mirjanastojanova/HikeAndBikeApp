using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIkeAndBikeAdminApplication.Models
{
    public class TrailInOrder
    {
        public Guid TrailId { get; set; }
        public Trail SelectedTrail { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }

        public int Quantity { get; set; }
    }
}
