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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MPS
{
    /// <summary>
    /// Логика взаимодействия для Cashier.xaml
    /// </summary>
    public partial class Cashier : Window
    {
        CrudOperation BD = new CrudOperation();
        List<ProductModel> products;
        List<CashierModel> cashiers;
        List<CategoryModel> categorys;
        int checkNum = 0;
        public Cashier()
        {
            InitializeComponent();
            products = BD.ProductList();
            cashiers = BD.CashierList();
            categorys = BD.CategoryList();
            FillProducts();
        }

        void FillProducts()
        {
            SpisokProduktov.ItemsSource = products;
        }

        private void Create_Reciept(object sender, RoutedEventArgs e)
        {
            if (ProductCount.Text == ""|| ProductCount.Text == "0"|| SpisokProduktov.SelectedItem == null)
            {
                MessageBox.Show("Не выбран продукт и/или не введено количество");
            }
            else if ( SpisokProduktov.SelectedItem != null)
            {
                if (checkNum == 0)
                {
                    RecieptModel reciept = new RecieptModel();
                    reciept.DateTime = DateTime.Now;
                    reciept.Result = 0;
                    reciept.Cashier_FK = Convert.ToInt32(CashierId.Text);
                    var element = BD.CreateReciept(reciept);
                    Console.WriteLine(element);
                    RecieptId.Text = Convert.ToString(element);
                    checkNum = 1;

                    var selectedItem = SpisokProduktov.SelectedItem;
                    TextBlock x = SpisokProduktov.Columns[0].GetCellContent(SpisokProduktov.Items[SpisokProduktov.SelectedIndex]) as TextBlock;

                    RecieptLineModel line = new RecieptLineModel();
                    line.Count = Convert.ToInt32(ProductCount.Text);
                    line.Reciept_FK = element;
                    line.Product_FK = Convert.ToInt32(x.Text);
                    BD.CreateLine(line);

                    var recieptId = element;
                    SpisokLines.ItemsSource = (System.Collections.IEnumerable)BD.PoiskLine(recieptId);
                }
                else if (checkNum == 1)
                {
                    var selectedItem = SpisokProduktov.SelectedItem;
                    TextBlock x = SpisokProduktov.Columns[0].GetCellContent(SpisokProduktov.Items[SpisokProduktov.SelectedIndex]) as TextBlock;

                    RecieptLineModel line = new RecieptLineModel();
                    line.Count = Convert.ToInt32(ProductCount.Text);
                    line.Reciept_FK = Convert.ToInt32(RecieptId.Text);
                    line.Product_FK = Convert.ToInt32(x.Text);
                    BD.CreateLine(line);

                    var recieptId = Convert.ToInt32(RecieptId.Text);
                    SpisokLines.ItemsSource = (System.Collections.IEnumerable)BD.PoiskLine(recieptId);
                }
            } 
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            CashierLogin cashierLogin = new CashierLogin();
            this.Close();
            cashierLogin.Show();
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
