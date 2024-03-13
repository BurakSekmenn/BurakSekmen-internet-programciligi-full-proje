using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Entity
{
    public class StockUpdatedEvent
    {
        public int ProductId { get; set; }
        public int QuantitySold { get; set; }
    }
}
