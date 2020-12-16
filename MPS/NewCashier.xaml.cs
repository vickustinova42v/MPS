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
    /// Логика взаимодействия для NewCashier.xaml
    /// </summary>
    public partial class NewCashier : Window
    {
        CrudOperation BD = new CrudOperation();
        Admin admin = new Admin();
        List<CashierModel> cashiers;
        public NewCashier()
        {
            InitializeComponent();
            cashiers = BD.CashierList();
        }

        private void UpdateСash(object sender, RoutedEventArgs e)
        {
            if (TextBoxCashier.Text == "")
            {
                MessageBox.Show("Заполните поле");
            }
            else
            {
                var function_id = TextBoxId.Text;
                var cashier_id = TextBoxCashId.Text;
                var fio = TextBoxCashier.Text;
                var login = TextBoxLogin.Text;
                var password = TextBoxPassword.Text;
                Console.WriteLine(function_id);
                if (function_id == "1")
                {
                    BD.UpdateCashier(cashier_id, fio, login, password);
                    MessageBox.Show("Кассир обновлен");
                }
                else if (function_id == "2")
                {
                    BD.CreateCashier(fio, login, password);
                    MessageBox.Show("Кассир добавлен");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                this.Close();
            }
        }
    }
}
