using HikeAndBike.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Domain.Domain
{
    public class ShoppingCart :BaseEntity
    {
        public string OwnerId { get; set; }
        public HikeAndBikeApplicationUser Owner { get; set; }

        public virtual ICollection<TrailInShoppingCart> TrailInShoppingCarts { get; set; }

    }
}
