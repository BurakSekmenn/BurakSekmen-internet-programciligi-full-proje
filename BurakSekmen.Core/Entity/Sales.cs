using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Entity
{
    public class Sales:BaseEntity
    {
        public int ProductId { get; set; }
        public int PersonId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public Product Product { get; set; }
        public Person Person { get; set; }
    }
}
