using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Domain.Domain
{
    public class TrailInOrder : BaseEntity
    {
        public Guid TrailId { get; set; }
        public Trail SelectedTrail { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }

        public int Quantity { get; set; }
    }
}
