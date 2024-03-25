using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.DTOs
{
    public class TaxDto:BaseDto
    {
        public string TaxName { get; set; } // Gelir Vergisi, KDV, ÖTV

        public decimal Rate { get; set; } = 0; // 0.18, 0.08, 0.20 Gider Oranı

        public decimal Price { get; set; } = 0; // 100 TL Fiyat Girilecek

        public DateTime PaymetDate { get; set; }

        public string Description { get; set; } // Açıklama

    }
}
