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

        public ServerResult<Flower> Get(int id)
        {
            Entities.Flower flower = _flowersRepo.Get(id);
            return new ServerResult<Flower>
            {
                Data = flower.ToDTO(),
                Success = true
            };
        }

        public ServerResult<List<Flower>> GetAll()
        {
            var flowers = _flowersRepo.GetAll();
            return new ServerResult<List<Flower>> 
            { 
                Data = flowers.Select(t => t.ToDTO()).ToList(),
                Success = true
            };
        }
    }
}
