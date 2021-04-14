using Superjonikai.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Services
{
    public interface IFlowersCatalogService
    {
        List<Flower> Get();
    }
}
