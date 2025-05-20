// файл: EkzamenWPF/Models/Material.cs
using System.Collections.Generic;

namespace EkzamenWPF.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        // Тип материала (Сырьё, Компонент, Упаковка)
        public string Type { get; set; }

        // Наименование материала
        public string Name { get; set; }

        // Цена за единицу (>= 0, с точностью до 0.01)
        public decimal Price { get; set; }

        // Единица измерения (шт., кг и т.п.)
        public string Unit { get; set; }

        // Количество в упаковке (целое, > 0)
        public int QuantityInPack { get; set; }

        // Текущее количество на складе (>= 0)
        public decimal QuantityInStock { get; set; }

        // Минимально допустимое количество (>= 0)
        public decimal MinimumAllowed { get; set; }

        // Навигационные свойства
        public ICollection<ProductMaterial> ProductMaterials { get; set; }
        public ICollection<MaterialHistory> History { get; set; }
    }
}
