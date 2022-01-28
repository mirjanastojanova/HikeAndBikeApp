using HikeAndBike.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Domain.DTO
{
    public class AddTrailToShoppingCartDto
    {
        public Trail SelectedTrail { get; set; }
        public Guid TrailId { get; set; }
        public int Quantity { get; set; }
    }
}
