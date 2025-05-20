using EkzamenWPF.dbcontext;
using EkzamenWPF.Models;
using System;
using System.Linq;
using System.Windows;

namespace EkzamenWPF
{
    public partial class ProductionCalculatorWindow : Window
    {
        public ProductionCalculatorWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new BD())
            {
                ProductTypeComboBox.ItemsSource = db.ProductTypes.ToList();
                MaterialTypeComboBox.ItemsSource = db.MaterialTypes.ToList();
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RawQtyTextBox.Text, out int rawQty) || rawQty <= 0)
            {
                MessageBox.Show("Введите корректное целое количество сырья.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(Param1TextBox.Text, out double param1) || param1 <= 0 ||
                !double.TryParse(Param2TextBox.Text, out double param2) || param2 <= 0)
            {
                MessageBox.Show("Оба параметра должны быть положительными числами.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ProductTypeComboBox.SelectedValue == null || MaterialTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип продукции и материала.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int productTypeId = (int)ProductTypeComboBox.SelectedValue;
            int materialTypeId = (int)MaterialTypeComboBox.SelectedValue;

            int result = CalculateProduction(productTypeId, materialTypeId, rawQty, param1, param2);
            if (result == -1)
            {
                MessageBox.Show("Ошибка расчёта: проверьте входные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ResultTextBlock.Text = $"Можно произвести: {result} шт продукции.";
        }

        /// <summary>
        /// Метод расчёта количества продукции из сырья
        /// </summary>
        private int CalculateProduction(int productTypeId, int materialTypeId, int rawQty, double param1, double param2)
        {
            using (var db = new BD())
            {
                var productType = db.ProductTypes.Find(productTypeId);
                var materialType = db.MaterialTypes.Find(materialTypeId);

                if (productType == null || materialType == null || param1 <= 0 || param2 <= 0 || rawQty <= 0)
                    return -1;

                double materialPerUnit = param1 * param2 * productType.Coefficient;
                if (materialPerUnit <= 0) return -1;

                double rawQtyAdjusted = rawQty * (1 - materialType.LossPercent / 100.0);
                int quantity = (int)(rawQtyAdjusted / materialPerUnit);

                return quantity >= 0 ? quantity : 0;
            }
        }
    }
}
