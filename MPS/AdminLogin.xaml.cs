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

namespace MPS
{
    /// <summary>
    /// Логика взаимодействия для AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        const string password = "12345";
        Admin admin = new Admin();

        private void CheckPassword(object sender, RoutedEventArgs e)
        {
            if (Password.Password == password)
            {
                this.Close();
                admin.Show();
            }
            else
            {
                MessageBox.Show("Пароль неверный");
            }
        }
    }
}
