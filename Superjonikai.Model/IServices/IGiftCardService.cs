using Superjonikai.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.IServices
{
    public interface IGiftCardService
    {
        ServerResult<List<GiftCard>> GetAll();
        ServerResult<GiftCard> Get(int id);
    }
}
