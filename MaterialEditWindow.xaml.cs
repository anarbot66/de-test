using EkzamenWPF.dbcontext;
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
using EkzamenWPF.models;
using EkzamenWPF.Models;

namespace EkzamenWPF
{
    /// <summary>
    /// Логика взаимодействия для MaterialEditWindow.xaml
    /// </summary>
    public partial class MaterialEditWindow : Window
    {
        private readonly int? _materialId;

        public MaterialEditWindow(int? materialId = null)
        {
            InitializeComponent();
            _materialId = materialId;
            LoadTypes();
            if (_materialId.HasValue)
                LoadExisting();
            else
                HeaderText.Text = "Добавление нового материала";
        }

        private void LoadTypes()
        {
            TypeCombo.ItemsSource = new[] { "Сырьё", "Компонент", "Упаковка" };
            TypeCombo.SelectedIndex = 0;
        }

        private void LoadExisting()
        {
            HeaderText.Text = "Редактирование материала";

            using (var db = new BD())
            {
                var m = db.Materials.Find(_materialId.Value);
                if (m == null) return;

                TypeCombo.SelectedItem = m.Type;
                NameText.Text = m.Name;
                PriceText.Text = m.Price.ToString("F2");
                UnitText.Text = m.Unit;
                PackQtyText.Text = m.QuantityInPack.ToString();
                StockQtyText.Text = m.QuantityInStock.ToString();
                MinQtyText.Text = m.MinimumAllowed.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new BD())
            {
                Material material;
                if (_materialId.HasValue)
                {
                    material = db.Materials.Find(_materialId.Value);
                    if (material == null) return;
                }
                else
                {
                    material = new Material();
                    db.Materials.Add(material);
                }

                material.Type = TypeCombo.SelectedItem.ToString();
                material.Name = NameText.Text.Trim();
                material.Price = decimal.Parse(PriceText.Text);
                material.Unit = UnitText.Text.Trim();
                material.QuantityInPack = int.Parse(PackQtyText.Text);
                material.QuantityInStock = decimal.Parse(StockQtyText.Text);
                material.MinimumAllowed = decimal.Parse(MinQtyText.Text);

                db.SaveChanges();
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
