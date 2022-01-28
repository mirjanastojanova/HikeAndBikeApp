using HikeAndBike.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string userId, Guid id);
        bool order(string userId);
    }
}
