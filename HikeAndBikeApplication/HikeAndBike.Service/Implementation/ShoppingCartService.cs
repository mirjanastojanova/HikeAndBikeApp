using HikeAndBike.Domain.Domain;
using HikeAndBike.Domain.DTO;
using HikeAndBike.Repository.Interface;
using HikeAndBike.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikeAndBike.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<TrailInOrder> _trailInOrderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> cartRepository,
            IUserRepository userRepository,
            IRepository<Order> orderRepository,
            IRepository<TrailInOrder> trailInOrderRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _trailInOrderRepository = trailInOrderRepository;
        }
        public bool deleteProductFromShoppingCart(string userId, Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                var user = this._userRepository.Get(userId);

                var userShoppingCart = user.UserCart;

                var itemToDelete = userShoppingCart.TrailInShoppingCarts.Where(z => z.TrailId.Equals(id)).FirstOrDefault();

                userShoppingCart.TrailInShoppingCarts.Remove(itemToDelete);

                this._cartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userShoppingCart = loggedInUser.UserCart;

            var allTrails = userShoppingCart.TrailInShoppingCarts.ToList();

            var allTrailPrice = allTrails.Select(z => new
            {
                TrailPrice = z.Trail.Price,
                Quantity = z.Quantity
            }).ToList();

            double totalPrice = 0;

            foreach (var item in allTrailPrice)
            {
                totalPrice += item.Quantity * item.TrailPrice;
            }

            ShoppingCartDto shoppingCartDtoItem = new ShoppingCartDto
            {
                TrailInShoppingCarts = allTrails,
                TotalPrice = totalPrice
            };

            return shoppingCartDtoItem;
        }

        public bool order(string userId)
        {
            if (!string.IsNullOrEmpty(userId)) {

                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    User = loggedInUser
                };

                this._orderRepository.Insert(order);

                List<TrailInOrder> trailInOrders = new List<TrailInOrder>();

                var result = userShoppingCart.TrailInShoppingCarts
                    .Select(z => new TrailInOrder
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order.Id,
                        TrailId = z.TrailId,
                        SelectedTrail = z.Trail,
                        UserOrder = order,
                        Quantity = z.Quantity
                    }).ToList();

                StringBuilder sb = new StringBuilder();

                double totalPrice = 0.0;

                sb.AppendLine("Your order is completed. The order contains: ");

                for (int i = 1; i <= result.Count(); i++)
                {
                    var item = result[i-1];

                    totalPrice += item.Quantity * item.SelectedTrail.Price;

                    sb.AppendLine(item.SelectedTrail.Name + " with price of: " + item.SelectedTrail.Price + " and quantity of: " + item.Quantity);
                }

                sb.AppendLine("Total price: " + totalPrice.ToString());


                trailInOrders.AddRange(result);

                foreach (var item in trailInOrders)
                {
                    this._trailInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.TrailInShoppingCarts.Clear();
               
                this._userRepository.Update(loggedInUser);

                return true;
            }
            return false;
        }     
    }
}
