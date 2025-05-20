using System;
using System.Collections.Generic;

namespace EkzamenWPF.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public int PlannedQuantity { get; set; }

        public ICollection<ProductMaterial> ProductMaterials { get; set; }
    }
}
