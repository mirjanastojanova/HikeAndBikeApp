using HikeAndBikeAdmin.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBikeAdmin.Service.Interface
{
    public interface ITrailService
    {
        List<Trail> GetAllTrails();
        Trail GetDetailsForTrail(Guid? id);
        void CreateNewTrail(Trail p);
        void UpdateExistingTrail(Trail p);
        void DeleteTrail(Guid id);
    }
}
