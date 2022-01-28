using HikeAndBike.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<HikeAndBikeApplicationUser> GetAll();
        HikeAndBikeApplicationUser Get(string id);
        void Insert(HikeAndBikeApplicationUser entity);
        void Update(HikeAndBikeApplicationUser entity);
        void Delete(HikeAndBikeApplicationUser entity);
    }
}
