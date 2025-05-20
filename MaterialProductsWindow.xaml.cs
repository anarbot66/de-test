using EkzamenWPF.dbcontext;
using System.Linq;
using System.Windows;

namespace EkzamenWPF
{
    public partial class MaterialProductsWindow : Window
    {
        private readonly int _materialId;

        public MaterialProductsWindow(int materialId)
        {
            InitializeComponent();
            _materialId = materialId;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new BD())
            {
                var list = db.ProductMaterials
                    .Where(pm => pm.MaterialId == _materialId)
                    .Select(pm => new
                    {
                        ProductName = pm.Product.Name,
                        RequiredQuantity = pm.QuantityPerUnit * pm.Product.PlannedQuantity
                    })
                    .ToList();

                ProductsGrid.ItemsSource = list;
            }
        }
    }
}
