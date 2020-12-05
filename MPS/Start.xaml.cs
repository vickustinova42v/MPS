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
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        CrudOperation BD = new CrudOperation();
        List<ProductModel> products;
        List<CashierModel> cashiers;
        List<CategoryModel> categorys;
        public Start()
        {
            InitializeComponent();
            products = BD.ProductList();
            cashiers = BD.CashierList();
            categorys = BD.CategoryList();
            Fill1();
            Fill2();
            Fill3();
        }
        void Fill1()
        {
            SpisokProductov.ItemsSource = products;
        }
        void Fill2()
        {
            SpisokCassirov.ItemsSource = cashiers;
        }

        void Fill3()
        {
            CahierCombobox.ItemsSource = cashiers;
            CahierCombobox.DisplayMemberPath = "FIO";
            CahierCombobox.SelectedValuePath = "Id";
        }
        private void Delete__Prod(object sender, RoutedEventArgs e)
        {
            if (SpisokProductov.SelectedItem == null)
                return;
            if (SpisokProductov.SelectedItem != null)
            {

                var selectedItem = SpisokProductov.SelectedItem;
                TextBlock x = SpisokProductov.Columns[0].GetCellContent(SpisokProductov.Items[SpisokProductov.SelectedIndex]) as TextBlock;

                if (x == null)
                {
                    MessageBox.Show("Продукт не найден");
                }
                else
                {
                    BD.DeleteProducts(x.Text);
                    SpisokProductov.ItemsSource = BD.ProductList();
                }
            }
        }

        private void Update__Prod(object sender, RoutedEventArgs e)
        {
            NewProduct f = new NewProduct();

            if (SpisokProductov.SelectedItem == null)
                return;
            if (SpisokProductov.SelectedItem != null)
            {

                var selectedItem = SpisokProductov.SelectedItem;
                TextBlock z = SpisokProductov.Columns[0].GetCellContent(SpisokProductov.Items[SpisokProductov.SelectedIndex]) as TextBlock;
                TextBlock x = SpisokProductov.Columns[1].GetCellContent(SpisokProductov.Items[SpisokProductov.SelectedIndex]) as TextBlock;
                TextBlock c = SpisokProductov.Columns[2].GetCellContent(SpisokProductov.Items[SpisokProductov.SelectedIndex]) as TextBlock;
                TextBlock v = SpisokProductov.Columns[3].GetCellContent(SpisokProductov.Items[SpisokProductov.SelectedIndex]) as TextBlock;
                TextBlock b = SpisokProductov.Columns[4].GetCellContent(SpisokProductov.Items[SpisokProductov.SelectedIndex]) as TextBlock;

                if (x == null)
                {
                    MessageBox.Show("Продукт не найден");
                }
                else
                {
                    //Console.WriteLine(v.Text);
                    //SpisokProductov.ItemsSource = BD.GetProduct(x.Text);
                    f.ComboBoxCashier.ItemsSource = categorys;
                    f.ComboBoxCashier.DisplayMemberPath = "Name";
                    f.ComboBoxCashier.SelectedValuePath = "Id";
                    foreach (var stream in categorys)
                        if (stream.Name == b.Text)
                        {
                            //Console.WriteLine(stream.Id - 1);
                            //Console.WriteLine(stream.Name);
                            f.ComboBoxCashier.SelectedIndex = stream.Id - 1;
                        }
                    f.TextBoxId.SelectedText = "1";
                    f.TextBoxProdId.SelectedText = z.Text;
                    f.TextBoxName.SelectedText = x.Text;
                    f.TextBoxNumber.SelectedText = c.Text;
                    f.TextBoxCost.SelectedText = v.Text;
                    f.Show();
                }
                SpisokProductov.Items.Refresh();
            }

        }

        private void Create__Prod(object sender, RoutedEventArgs e)
        {
            NewProduct f = new NewProduct();
            f.ComboBoxCashier.ItemsSource = categorys;
            f.ComboBoxCashier.DisplayMemberPath = "Name";
            f.ComboBoxCashier.SelectedValuePath = "Id";
            f.ComboBoxCashier.SelectedIndex = 1;
            f.TextBoxId.SelectedText = "2";
            f.Show();
            SpisokProductov.Items.Refresh();
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
                {
                    MessageBox.Show("Кассир не найден");
                }
                else
                {
                    BD.DeleteCashiers(x.Text);
                    SpisokCassirov.ItemsSource = BD.CashierList();
                    CahierCombobox.ItemsSource = BD.CashierList();
                }
            }
        }

        private void Update__Сash(object sender, RoutedEventArgs e)
        {
            NewCashier f = new NewCashier();
            if (SpisokCassirov.SelectedItem == null)
                return;
            if (SpisokCassirov.SelectedItem != null)
            {

                var selectedItem = SpisokCassirov.SelectedItem;
                TextBlock z = SpisokCassirov.Columns[0].GetCellContent(SpisokCassirov.Items[SpisokCassirov.SelectedIndex]) as TextBlock;
                TextBlock x = SpisokCassirov.Columns[1].GetCellContent(SpisokCassirov.Items[SpisokCassirov.SelectedIndex]) as TextBlock;

                if (x == null)
                {
                    MessageBox.Show("Продукт не найден");
                }
                else
                {
                    f.TextBoxId.SelectedText = "1";
                    f.TextBoxCashId.SelectedText = z.Text;
                    f.TextBoxCashier.SelectedText = x.Text;
                    f.Show();
                }
                SpisokCassirov.Items.Refresh();
            }
        }

        private void Create__Сash(object sender, RoutedEventArgs e)
        {
            NewCashier f = new NewCashier();
            f.TextBoxId.SelectedText = "2";
            f.Show();
            SpisokCassirov.Items.Refresh();
        }

        private void SearchCash(object sender, RoutedEventArgs e)
        {
            if (CahierCombobox.SelectedValue == null)
            {
                MessageBox.Show("Кассир не выбран");
            }
            else
            {
                int id_cashier = (int)CahierCombobox.SelectedValue;
                CashierResult.ItemsSource = (System.Collections.IEnumerable)BD.SearchRecieptCashier(id_cashier);
            }

        }

        private void SearchDate(object sender, RoutedEventArgs e)
        {
            if (DatePickerLeft.SelectedDate == null || DatePickerRight.SelectedDate == null)
            {
                MessageBox.Show("Не выбрана дата");
            }
            else
            {
                DateTime selectedDateLeft = (DateTime)DatePickerLeft.SelectedDate;
                DateTime selectedDateRight = (DateTime)DatePickerRight.SelectedDate;
                DateResult.ItemsSource = (System.Collections.IEnumerable)BD.SearchRecieptDate(selectedDateLeft, selectedDateRight);
            }
        }

        private void Update__Window(object sender, RoutedEventArgs e)
        {
            Start newWindow = new Start();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }
    }
}
