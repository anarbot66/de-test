using System.ComponentModel.DataAnnotations;

namespace EkzamenWPF.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Coefficient { get; set; }
    }
}
