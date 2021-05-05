using Superjonikai.Model.DTO;
using System.Collections.Generic;

namespace Superjonikai.Model.Services
{
    public interface IFlowersCatalogService
    {
        List<Flower> GetAll();
        Flower Get(int id);
    }
}
