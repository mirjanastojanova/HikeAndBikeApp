using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBikeAdmin.Domain.Domain
{
    public class TrailInOrder
    {
        public Guid Id { get; set; }
        public Guid TrailId { get; set; }
        public Trail SelectedTrail { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }

        public int Quantity { get; set; }

    }
}
