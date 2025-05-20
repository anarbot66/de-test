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
using EkzamenWPF.dbcontext;

namespace EkzamenWPF
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string username = LoginNew.Text.Trim();
            string password = Parol.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните поля перед регистрацией");
                return;
            }

            using (var db = new BD())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user != null) {
                    MessageBox.Show("Вы успешно вошли");
                    var Material = new MaterialsWindow();
                    Material.Show();
                    this.Hide();
                } else
                {
                    return;
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
