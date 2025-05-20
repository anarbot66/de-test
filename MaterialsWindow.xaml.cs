using EkzamenWPF.dbcontext;
using EkzamenWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EkzamenWPF
{
    /// <summary>
    /// Логика взаимодействия для MaterialsWindow.xaml
    /// </summary>
    public partial class MaterialsWindow : Window
    {
        public MaterialsWindow()
        {
            InitializeComponent();
            LoadMaterials();
        }
        private void LoadMaterials()
        {
            using (var db = new BD())
            {
                var list = db.Materials
                    .Select(m => new
                    {
                        m.MaterialId,
                        m.Type,
                        m.Name,
                        m.Price,
                        m.Unit,
                        m.QuantityInPack,
                        m.QuantityInStock,
                        m.MinimumAllowed,
                        Required = Math.Round(
                            db.ProductMaterials
                              .Where(pm => pm.MaterialId == m.MaterialId)
                              .Sum(pm => pm.QuantityPerUnit * pm.Product.PlannedQuantity),
                            2)
                    })
                    .ToList();

                MaterialsGrid.ItemsSource = list;
            }
        }


        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите материал.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            dynamic selected = MaterialsGrid.SelectedItem;
            int materialId = selected.MaterialId;

            using (var db = new BD())
            {
                var material = db.Materials.Find(materialId);

                if (material == null)
                {
                    MessageBox.Show("Материал не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                decimal required = db.ProductMaterials
                    .Where(pm => pm.MaterialId == materialId)
                    .Sum(pm => pm.QuantityPerUnit * pm.Product.PlannedQuantity);

                required = Math.Round(required, 2);

                if (material.QuantityInStock < required)
                {
                    MessageBox.Show("Недостаточно материала на складе.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                decimal before = material.QuantityInStock;
                material.QuantityInStock -= required;

                var historyEntry = new MaterialHistory
                {
                    MaterialId = materialId,
                    ChangeDate = DateTime.Now,
                    QuantityBefore = before,
                    QuantityAfter = material.QuantityInStock,
                    Comment = "Резерв под производство"
                };

                db.MaterialHistory.Add(historyEntry);
                db.SaveChanges();

                MessageBox.Show($"Материал зарезервирован в количестве {required:N2}.",
                                "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadMaterials();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new MaterialEditWindow();
            editWindow.Owner = this;
            if (editWindow.ShowDialog() == true)
                LoadMaterials();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsGrid.SelectedItem == null)
            {
                MessageBox.Show(
                    "Пожалуйста, выберите материал для редактирования.",
                    "Предупреждение",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            dynamic sel = MaterialsGrid.SelectedItem;
            int id = sel.MaterialId;

            var editWindow = new MaterialEditWindow(id);
            editWindow.Owner = this;
            if (editWindow.ShowDialog() == true)
                LoadMaterials();
        }

        private void ViewProductsButton_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите материал для просмотра продукции.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            dynamic sel = MaterialsGrid.SelectedItem;
            int materialId = sel.MaterialId;

            var window = new MaterialProductsWindow(materialId);
            window.Owner = this;
            window.ShowDialog();
        }

        private void OpenProductionCalculator_Click(object sender, RoutedEventArgs e)
        {
            var calcWindow = new ProductionCalculatorWindow();
            calcWindow.Owner = this;
            calcWindow.ShowDialog();
        }


    }
}
