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
            Products.ItemsSource = products;
        }

        private void Create_Reciept(object sender, RoutedEventArgs e)
        {
            RecieptModel chek = new RecieptModel();
            chek.DateTime= DateTime.Now;
            chek.Result = 999999;
            chek.Cashier_FK = Convert.ToInt32(CashierId.Text);
            //BD.CreateReciept(chek);
            var element = BD.CreateReciept(chek);
            Console.WriteLine(element);
            RecieptId.Text = Convert.ToString(element);
        }
    }
}
