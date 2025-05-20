using System.ComponentModel.DataAnnotations;

namespace EkzamenWPF.Models
{
    public class MaterialType
    {
        [Key]
        public int MaterialTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        // Процент потерь при производстве (например, 5.0 означает 5%)
        [Required]
        public double LossPercent { get; set; }
    }
}
