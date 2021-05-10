using Superjonikai.Model.DTO;
using System.Collections.Generic;

namespace Superjonikai.Model.IServices
{
    public interface IFlowersCatalogService
    {
        ServerResult<List<Flower>> GetAll();
        ServerResult<Flower> Get(int id);
    }
}
