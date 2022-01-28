using HikeAndBike.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TrailInShoppingCart> TrailInShoppingCarts { get; set; }
        public double TotalPrice { get; set; }
    }
}
