using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.DTOs
{
    public class ProductFeatureAndProductinfoDtos:ProductDto
    {
        public List<ProductFeatureDto> ProductFeatures { get; set; }
        public Product Product { get; set; } 
    }
}
