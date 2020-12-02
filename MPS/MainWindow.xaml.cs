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

        }
    }
}
