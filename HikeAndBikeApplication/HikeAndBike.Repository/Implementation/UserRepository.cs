using HikeAndBike.Domain.Identity;
using HikeAndBike.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikeAndBike.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<HikeAndBikeApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<HikeAndBikeApplicationUser>();
        }
        public IEnumerable<HikeAndBikeApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public HikeAndBikeApplicationUser Get(string id)
        {
            return entities
               .Include(z => z.UserCart)
               .Include("UserCart.TrailInShoppingCarts")
               .Include("UserCart.TrailInShoppingCarts.Trail")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(HikeAndBikeApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(HikeAndBikeApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(HikeAndBikeApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
