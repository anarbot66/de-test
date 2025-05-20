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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EkzamenWPF.dbcontext;
using EkzamenWPF.models;

namespace EkzamenWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new BD())
            {
                db.Database.EnsureCreated();
                string username = Login.Text.Trim();
                string password = Parol.Text.Trim();

                if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Заполните поля перед регистрацией");
                    return;
                }

                if (db.Users.Any(u => u.UserName == username)) {
                    MessageBox.Show("Такой юзер уже есть");
                    return;
                }

                db.Users.Add(new User { Password = password, UserName = username });
                db.SaveChanges();
                MessageBox.Show("Вы успешно зарегались");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
