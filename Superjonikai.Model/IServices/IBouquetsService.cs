using Superjonikai.Model.DTO;
using System.Collections.Generic;

namespace Superjonikai.Model.IServices
{
    public interface IBouquetsService
    {
        ServerResult<List<Bouquet>> GetAll();
        ServerResult<Bouquet> Get(int id);
    }
}
