using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Domain.Domain
{
    public class TrailInShoppingCart : BaseEntity
    {
        public Guid TrailId { get; set; }
        public Trail Trail { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
