using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Superjonikai.Model.Services
{
    class BouquetsService : IBouquetsService
    {
        private readonly IBouquetRepository _bouqRepo;

        public BouquetsService(IBouquetRepository bouqRepo)
        {
            _bouqRepo = bouqRepo;
        }

        public List<Bouquet> GetAll()
        {
            return _bouqRepo.GetAll().Select(e => e.ToDTO()).ToList();
        }

        Bouquet IBouquetsService.Get(int id)
        {
            Entities.Bouquet bouquet = _bouqRepo.Get(id);
            return bouquet?.ToDTO();
        }
    }
}
