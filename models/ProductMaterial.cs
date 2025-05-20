using EkzamenWPF.models;
using System;

namespace EkzamenWPF.Models
{
    public class ProductMaterial
    {
        public int ProductMaterialId { get; set; }

        // FK к Product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // FK к Material
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public decimal QuantityPerUnit { get; set; }
    }
}
