using BLL;
using BLL.Models;
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
    /// Логика взаимодействия для CashierLogin.xaml
    /// </summary>
    public partial class CashierLogin : Window
    {
        CrudOperation BD = new CrudOperation();
        List<CashierModel> cashiers;
        
        public CashierLogin()
        {
            InitializeComponent();
            cashiers = BD.CashierList();
        }

        private void CheckPassword(object sender, RoutedEventArgs e)
        {
            Cashier cashier = new Cashier();
            foreach (var stream in cashiers)
            if (stream.Login == Login.Text && stream.Password == Password.Password)
            {
                cashier.CashierName.Text = stream.FIO;
                cashier.CashierId.Text = stream.Id.ToString();
                cashier.Show();
                this.Close();
            }
        }

        private void AdminLogin(object sender, RoutedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            this.Close();
            adminLogin.Show();
        }
    }
}
