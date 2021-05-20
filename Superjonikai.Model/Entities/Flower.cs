using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Superjonikai.Model.Entities
{
    public class Flower
    {
        [Key, Required]
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public double Price { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Color { get; set; }
        [NotMapped]
        public virtual ICollection<FlowerOrder> Orders { set; get; }

        //photo

        public Flower()
        {

        }
    }
}
