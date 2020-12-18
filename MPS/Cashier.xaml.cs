using BLL;
using BLL.Models;
using System;
using System.IO;
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
        int checkNum = 0;
        public Cashier()
        {
            InitializeComponent();
            products = BD.ProductList();
            ProductCount.Text = "1";
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
                    TextBlock y = SpisokProduktov.Columns[3].GetCellContent(SpisokProduktov.Items[SpisokProduktov.SelectedIndex]) as TextBlock;

                    int price = Convert.ToInt32(y.Text);
                    int count = Convert.ToInt32(ProductCount.Text);

                    RecieptLineModel line = new RecieptLineModel();
                    line.Count = Convert.ToInt32(ProductCount.Text);
                    line.Reciept_FK = element;
                    line.Product_FK = Convert.ToInt32(x.Text);
                    line.Count_Sum = price * count;
                    BD.CreateLine(line);

                    var recieptId = element;
                    SpisokLines.ItemsSource = (System.Collections.IEnumerable)BD.PoiskLine(recieptId);

                    var resultOfReciept = BD.ResultReciept(recieptId);
                    RecieptResult.Text = resultOfReciept;
                }
                else if (checkNum == 1)
                {
                    var selectedItem = SpisokProduktov.SelectedItem;
                    TextBlock x = SpisokProduktov.Columns[0].GetCellContent(SpisokProduktov.Items[SpisokProduktov.SelectedIndex]) as TextBlock;
                    TextBlock y = SpisokProduktov.Columns[3].GetCellContent(SpisokProduktov.Items[SpisokProduktov.SelectedIndex]) as TextBlock;

                    int price = Convert.ToInt32(y.Text);
                    int count = Convert.ToInt32(ProductCount.Text);

                    RecieptLineModel line = new RecieptLineModel();
                    line.Count = Convert.ToInt32(ProductCount.Text);
                    line.Reciept_FK = Convert.ToInt32(RecieptId.Text);
                    line.Product_FK = Convert.ToInt32(x.Text);
                    line.Count_Sum = price * count;
                    BD.CreateLine(line);

                    var recieptId = Convert.ToInt32(RecieptId.Text);
                    SpisokLines.ItemsSource = (System.Collections.IEnumerable)BD.PoiskLine(recieptId);

                    var resultOfReciept = BD.ResultReciept(recieptId);
                    RecieptResult.Text = resultOfReciept;
                }
            } 
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            if (SpisokLines.Items.Count >=2)
            {
                MessageBox.Show("Необходимо сохранить чек");
            }
            else
            {
                CashierLogin cashierLogin = new CashierLogin();
                this.Close();
                cashierLogin.Show();
            }
        }

        private void DeleteLine(object sender, RoutedEventArgs e)
        {
             if (SpisokLines.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана строка чека");
            }
            else if(SpisokLines.Items.Count-2 == SpisokLines.SelectedIndex && SpisokLines.Items.Count==2)
            {
                MessageBox.Show("Невозможно удалить последний элемент");
            }
             else if (SpisokLines.SelectedItem != null)
            {
                TextBlock x = SpisokLines.Columns[0].GetCellContent(SpisokLines.Items[SpisokLines.SelectedIndex]) as TextBlock;
                if (x == null)
                {
                    MessageBox.Show("Продукт не найден");
                }
                else
                {
                    BD.DeleteLines(x.Text);
                    var recieptId = Convert.ToInt32(RecieptId.Text);
                    SpisokLines.ItemsSource = (System.Collections.IEnumerable)BD.PoiskLine(recieptId);
                    var resultOfReciept = BD.ResultReciept(recieptId);
                    RecieptResult.Text = resultOfReciept;
                }
            }
        }

        private void CalcChange(object sender, RoutedEventArgs e)
        {
            if (InputSumm.Text == "") 
            {
                MessageBox.Show("Введите сумму");
            }
            else
            {
                int recieptResult = Convert.ToInt32(RecieptResult.Text);
                int peopleResult = Convert.ToInt32(InputSumm.Text);
                if(peopleResult - recieptResult < 0)
                {
                    MessageBox.Show("Отрицательная сдача");
                }
                else
                {
                    Change.Text = Convert.ToString(peopleResult - recieptResult);
                }
            }
        }

        private void SaveReciept(object sender, RoutedEventArgs e)
        {
            if (Change.Text == ""|| Convert.ToInt32(Change.Text)<0)
            {
                MessageBox.Show("Посчитайте сдачу");
            }
            else
            {
                RecieptModel reciept = new RecieptModel();
                reciept.Id = Convert.ToInt32(RecieptId.Text);
                reciept.Result = Convert.ToInt32(RecieptResult.Text);
                reciept.Cashier_FK = Convert.ToInt32(CashierId.Text);
                BD.UpdateReciept(reciept);

                StreamWriter sw = new StreamWriter("C:\\Users\\Viktoria\\source\\repos\\MPS\\Reciepts\\" + RecieptId.Text + ".txt");
                sw.WriteLine("Фотостудия PhotoLife");
                sw.WriteLine("Кол-во Название Цена");
                sw.WriteLine("---------------");
                for (int i = 0; i< SpisokLines.Items.Count-1; i++)
                {
                    TextBlock a = SpisokLines.Columns[1].GetCellContent(SpisokLines.Items[i]) as TextBlock;
                    string d = a.Text;
                    TextBlock b = SpisokLines.Columns[2].GetCellContent(SpisokLines.Items[i]) as TextBlock;
                    string s = b.Text;
                    TextBlock c = SpisokLines.Columns[3].GetCellContent(SpisokLines.Items[i]) as TextBlock;
                    string l = c.Text;
                    sw.WriteLine(d +" "+ s + " " + l);
                }
                sw.WriteLine("---------------");
                sw.WriteLine("Сумма чека" + " " + RecieptResult.Text);
                sw.WriteLine("Введенная сумма" + " " + InputSumm.Text);
                sw.WriteLine("Сдача" + " " + Change.Text);
                sw.WriteLine("---------------");
                sw.WriteLine("Номер чека" + " " + RecieptId.Text);
                sw.WriteLine("Кассир" + " " + CashierName.Text);
                sw.WriteLine("Дата и время" + " " + DateTime.Now);
                sw.Close();
                MessageBox.Show("Чек сохранен");

                checkNum = 0;
                SpisokLines.ItemsSource = null;
                ProductCount.Text = "1";
                Change.Text = "";
                InputSumm.Text = "";
                RecieptResult.Text = "";
                RecieptId.Text = "";
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
