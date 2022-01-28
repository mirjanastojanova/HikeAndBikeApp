using HikeAndBike.Domain.Domain;
using HikeAndBike.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Service.Interface
{
    public interface ITrailService
    {
        List<Trail> GetAllTrails();
        Trail GetDetailsForTrail(Guid? id);
        void CreateNewTrail(Trail p);
        void UpdateExistingTrail(Trail p);
        AddTrailToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteTrail(Guid id);
        bool AddToShoppingCart(AddTrailToShoppingCartDto item, string userID);
    }
}
