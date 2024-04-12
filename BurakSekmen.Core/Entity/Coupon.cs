using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Entity
{
    public class Coupon:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string recordingname { get; set; }

    }
}
