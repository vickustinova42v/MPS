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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CrudOperation BD = new CrudOperation();
        List<ProductModel> products;
        List<CashierModel> cashiers;
      
        public MainWindow()
        {
            InitializeComponent();
            products = BD.ProductList();
            cashiers = BD.CashierList();
            Fill1();
            Fill2();
        }
        void Fill1()
        {
            SpisokProductov.ItemsSource = products;
        }
        void Fill2()
        {
            SpisokCassirov.ItemsSource = cashiers;
        }
        private void Delete__Prod(object sender, RoutedEventArgs e)
        {
            if (SpisokProductov.SelectedItem == null)
                return;
            if (SpisokProductov.SelectedItem != null) {

                var selectedItem = SpisokProductov.SelectedItem;
                TextBlock x = SpisokProductov.Columns[0].GetCellContent(SpisokProductov.Items[SpisokProductov.SelectedIndex]) as TextBlock;

                if (x == null)
                    MessageBox.Show("Продукт не найден");

                BD.DeleteProducts(x.Text);
                SpisokProductov.ItemsSource = BD.ProductList();
                //SpisokProductov.Items.Refresh();
            }
        }

        private void Update__Prod(object sender, RoutedEventArgs e)
        {
            NewProduct f = new NewProduct();
        }

        private void Create__Prod(object sender, RoutedEventArgs e)
        {
            NewProduct f = new NewProduct();
        }

        private void Delete__Сash(object sender, RoutedEventArgs e)
        {
            if (SpisokCassirov.SelectedItem == null)
                return;
            if (SpisokCassirov.SelectedItem != null)
            {
                var selectedItem = SpisokCassirov.SelectedItem;
                TextBlock x = SpisokCassirov.Columns[0].GetCellContent(SpisokCassirov.Items[SpisokCassirov.SelectedIndex]) as TextBlock;

                if (x == null)
                    MessageBox.Show("Продукт не найден");

                BD.DeleteCashiers(x.Text);
                SpisokCassirov.ItemsSource = BD.CashierList();
                //SpisokProductov.Items.Refresh();
            }
        }

        private void Update__Сash(object sender, RoutedEventArgs e)
        {

        }

        private void Create__Сash(object sender, RoutedEventArgs e)
        {

        }
    }
}
