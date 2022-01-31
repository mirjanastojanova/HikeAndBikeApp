using HikeAndBikeAdmin.Domain.Domain;
using HikeAndBikeAdmin.Repository.Interface;
using HikeAndBikeAdmin.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikeAndBikeAdmin.Service.Implementation
{
    public class TrailService : ITrailService
    {

        private readonly IRepository<Trail> _trailRepository;
        public TrailService(IRepository<Trail> trailRepository)
        {
            _trailRepository = trailRepository;
        }

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

        public void UpdateExistingTrail(Trail p)
        {
            this._trailRepository.Update(p);
        }
    }
}

