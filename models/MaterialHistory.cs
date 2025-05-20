using System;

namespace EkzamenWPF.Models
{
    public class MaterialHistory
    {
        public int MaterialHistoryId { get; set; }

        // FK к Material
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public DateTime ChangeDate { get; set; }
        public decimal QuantityBefore { get; set; }
        public decimal QuantityAfter { get; set; }
        public string Comment { get; set; }
    }
}
