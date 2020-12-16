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
    /// Логика взаимодействия для NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        Sales sales = new Sales();
        public NewProduct()
        {
            InitializeComponent();
        }

        public void UpdateProd(object sender, RoutedEventArgs e)
        {
            int sale = 0;
            if (BlackRad.IsChecked == true)
            {
                sale = 1;
            }
            else if (SummerRad.IsChecked == true)
            {
                sale = 2;
            }
            else if (ZeroRad.IsChecked == true)
            {
                sale = 0;
            }
            else
            {
                MessageBox.Show("Ошибка");
            }


            if (TextBoxName.Text ==""  || TextBoxNumber.Text == "" || TextBoxCost.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }

            else
            {
                var function_id = TextBoxId.Text;
                var product_id = TextBoxProdId.Text;
                var category_id = ComboBoxCashier.SelectedValue;
                var name = TextBoxName.Text;
                var number = TextBoxNumber.Text;
                var cost = Convert.ToInt32(TextBoxCost.Text);
                if (function_id == "1")
                {
                    sales.Update(product_id, name, number, cost, (int)category_id, sale, function_id);
                    MessageBox.Show("Продукт обновлен");
                }
                else if (function_id == "2")
                {
                    sales.Update(product_id, name, number, cost, (int)category_id, sale, function_id);
                    MessageBox.Show("Продукт добавлен");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                this.Close();
            }
        }

        private void NumericOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }
    }
}
