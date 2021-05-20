using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Superjonikai.Model.DTO
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string DeliveryDate { get; set; }
        public string Status { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
