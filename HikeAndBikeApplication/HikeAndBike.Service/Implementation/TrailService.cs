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
    public class TrailService : ITrailService
    {
        private readonly IRepository<Trail> _trailRepository;
        private readonly IRepository<TrailInShoppingCart> _trailInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        public TrailService(IRepository<Trail> trailRepository,
            IUserRepository userRepository,
            IRepository<TrailInShoppingCart> trailInShoppingCartRepository) {
            _trailRepository = trailRepository;
            _userRepository = userRepository;
            _trailInShoppingCartRepository = trailInShoppingCartRepository;
    }

        public bool AddToShoppingCart(AddTrailToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCart = user.UserCart;

            if (item.TrailId != null && userShoppingCart != null)
            {
                var trail = this.GetDetailsForTrail(item.TrailId);

                if (trail != null)
                {
                    if (userShoppingCart.TrailInShoppingCarts.Count() != 0)
                    {
                        var i = 0;
                        foreach (var t in userShoppingCart.TrailInShoppingCarts)
                        {
                            i++;
                            if (t.Trail.Id == item.TrailId)
                            {
                                t.Quantity += item.Quantity;

                                this._trailInShoppingCartRepository.Update(t);

                                return true;
                            }
                        }

                        TrailInShoppingCart itemToAdd = new TrailInShoppingCart
                        {
                            Trail = trail,
                            TrailId = trail.Id,
                            ShoppingCart = userShoppingCart,
                            ShoppingCartId = userShoppingCart.Id,
                            Quantity = item.Quantity
                        };
                        this._trailInShoppingCartRepository.Insert(itemToAdd);
                        return true;
                    }
                    else
                    {
                        TrailInShoppingCart itemToAdd = new TrailInShoppingCart
                        {
                            Trail = trail,
                            TrailId = trail.Id,
                            ShoppingCart = userShoppingCart,
                            ShoppingCartId = userShoppingCart.Id,
                            Quantity = item.Quantity
                        };
                        this._trailInShoppingCartRepository.Insert(itemToAdd);
                        return true;
                    }
                }

                return false;
            }
            return false;
        }

        //public bool AddToShoppingCart(AddTrailToShoppingCartDto item, string userID)
        //{

        //    var user = this._userRepository.Get(userID);

        //    var userShoppingCard = user.UserCart;

        //    if (item.TrailId != null && userShoppingCard != null)
        //    {
        //        var product = this.GetDetailsForTrail(item.TrailId);

        //        if (product != null)
        //        {
        //            TrailInShoppingCart itemToAdd = new TrailInShoppingCart
        //            {
        //                Id = Guid.NewGuid(),
        //                Trail = product,
        //                TrailId = product.Id,
        //                ShoppingCart = userShoppingCard,
        //                ShoppingCartId = userShoppingCard.Id,
        //                Quantity = item.Quantity
        //            };

        //            this._trailInShoppingCartRepository.Insert(itemToAdd);
        //            return true;
        //        }
        //        return false;
        //    }
        //    return false;
        //}

        public void CreateNewTrail(Trail p)
        {
            this._trailRepository.Insert(p);
        }

        public void DeleteTrail(Guid id)
        {
            var trail = this.GetDetailsForTrail(id);
            this._trailRepository.Delete(trail);
        }

        public List<Trail> GetAllTrails()
        {
            return this._trailRepository.GetAll().ToList();
        }

        public Trail GetDetailsForTrail(Guid? id)
        {
            return this._trailRepository.Get(id);
        }

        public AddTrailToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var trail = this.GetDetailsForTrail(id);
            AddTrailToShoppingCartDto model = new AddTrailToShoppingCartDto
            {
                SelectedTrail = trail,
                TrailId = trail.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdateExistingTrail(Trail p)
        {
            this._trailRepository.Update(p);
        }
    }
}
