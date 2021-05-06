using Superjonikai.Model.DTO;
using System.Collections.Generic;

namespace Superjonikai.Model.IServices
{
    public interface IFlowersCatalogService
    {
        List<Flower> GetAll();
        Flower Get(int id);
    }
}
