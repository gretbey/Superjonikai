using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Superjonikai.Model.Services
{
    public class FlowersCatalogService: IFlowersCatalogService
    {
        private readonly IFlowerRepository _flowersRepo;

        public FlowersCatalogService(IFlowerRepository flowersRepo)
        {
            _flowersRepo = flowersRepo;
        }

        public Flower Get(int id)
        {
            Entities.Flower flower = _flowersRepo.Get(id);
            return flower?.ToDTO();
        }

        public List<Flower> GetAll()
        {
            return _flowersRepo.GetAll().Select(e => e.ToDTO()).ToList();
        }
    }
}
