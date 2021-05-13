using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superjonikai.Model.Entities;
using Superjonikai.Model.Repository;

namespace Superjonikai.DB.SQLRepository
{
    public class BouquetSqlRepository : IBouquetRepository
    {
        private readonly DBContext context;

        public BouquetSqlRepository(DBContext context)
        {
            this.context = context;
        }
        public Bouquet Add(Bouquet bouquet)
        {
            context.Bouquets.Add(bouquet);
            context.SaveChanges();
            return bouquet;
        }

        public Bouquet Delete(int id)
        {
            Bouquet bouquet = context.Bouquets.Find(id);
            if (bouquet != null)
            {
                context.Bouquets.Remove(bouquet);
                context.SaveChanges();
            }
            return bouquet;
        }

        public Bouquet Get(int id)
        {
            return context.Bouquets.Find(id);
        }

        public List<Bouquet> GetAll()
        {
            return context.Bouquets.ToList();
        }

        public Bouquet Update(Bouquet updatedBouquet)
        {
            var bouquet = context.Bouquets.Attach(updatedBouquet);
            bouquet.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedBouquet;
        }
    }
}
