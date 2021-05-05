using Superjonikai.Model.DTO;
using System.Collections.Generic;

namespace Superjonikai.Model.IServices
{
    public interface IBouquetsService
    {
        List<Bouquet> GetAll();
        Bouquet Get(int id);
    }
}
