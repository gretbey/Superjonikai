using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Superjonikai.Model.Services
{
    public class BouquetsService : IBouquetsService
    {
        private readonly IBouquetRepository _bouqRepo;

        public BouquetsService(IBouquetRepository bouqRepo)
        {
            _bouqRepo = bouqRepo;
        }

        public ServerResult<List<Bouquet>> GetAll()
        {
            var bouquets = _bouqRepo.GetAll();
            return new ServerResult<List<Bouquet>> 
            { 
                Data = bouquets.Select(t => t.ToDTO()).ToList(), 
                Success = true 
            };
        }

        ServerResult<Bouquet> IBouquetsService.Get(int id)
        {
            Entities.Bouquet bouquet = _bouqRepo.Get(id);
            return new ServerResult<Bouquet>
            {
                Data = bouquet.ToDTO(),
                Success = true
            };
        }
    }
}
