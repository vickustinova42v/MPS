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
        CrudOperation BD = new CrudOperation();
        public NewProduct()
        {
            InitializeComponent();
        }

        private void UpdateProd(object sender, RoutedEventArgs e)
        {
            var function_id = TextBoxId.Text;
            var product_id = TextBoxProdId.Text;
            var category_id = ComboBoxCashier.SelectedValue;
            var name = TextBoxName.Text;
            var number = TextBoxNumber.Text;
            var cost = Convert.ToInt32(TextBoxCost.Text);

            Console.WriteLine(function_id);
            if (function_id == "1")
            {
                BD.UpdateProduct(product_id, name, number, cost, (int)category_id);
            }
            else if (function_id == "2")
            {

            }
            else
            {
                MessageBox.Show("Ошибка");
            }
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.UpdateLayout();
        }
    }
}
