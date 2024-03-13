using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.DTOs
{
    public class SalesDto:BaseDto
    {
      
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //public decimal? TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int PersonId { get; set; }
    }
}
