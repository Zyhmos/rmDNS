using Newtonsoft.Json;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string url = "https://localhost:7205/api/shop/";
        public DataTable dt;

        public MainWindow()
        {
            InitializeComponent();
            //Should be using serverside time. ¯\_(ツ)_/¯
            dpDate.SelectedDate = DateTime.Now;
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Address", typeof(String)));
            dt.Columns.Add(new DataColumn("Amount", typeof(String)));
            dt.Columns.Add(new DataColumn("Date", typeof(String)));
            dt.Columns.Add(new DataColumn("Total", typeof(String)));
        }


        private void tbAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ///You probably want me to make a try/catch validation on the server-side
            ///so that you could test -1,99999,00,abc,!@#$ and whatnot, but like
            ///I'd just never let the user even enter anything except 1-999 here.
            Regex regex = new((tbAmount.Text == string.Empty) ? "[^1-9]+" : "[^0-9]+");
            e.Handled = regex.IsMatch(e.Text.ToString());
        }

        private void tbAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbAmount.Text == "")
            {
                tbAmount.Text = "1";
                tbAmount.SelectAll();
            }
            int amount = System.Convert.ToInt32(tbAmount.Text);
            int disc = Discounter(amount);

            lblTotalCost.Content = String.Format("Total cost: {0}\n(" + disc + " % discount!)",
                TotalSum(amount));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate.SelectedDate <= DateTime.Now.Date)
            {
                MessageBox.Show("Date must be in future!");
                return;
            }
            else
            {
                var person = new Person();
                person.SetAddress(tbAddress.Text);
                person.SetName(tbName.Text);

                var order = new Order();
                order.SetPerson(person);
                order.SetDate(dpDate.SelectedDate);
                order.SetAmount(System.Convert.ToInt32(tbAmount.Text));

                _ = SendOrderAsync(order);
            }

        }

        private void btShowAll_Click(object sender, RoutedEventArgs e)
        {
            _ = GetOrderAsync();
        }

        private async Task SendOrderAsync(Order order)
        {
            var client = new API();
            //Should probably put IP and port into a settings file.
            //...Should probably make a settings file...
            _ = client.PostOrder(url, order);
            MessageBox.Show("Order sent!");
        }

        private async Task GetOrderAsync()
        {
            var client = new API();
            var data = await client.GetOrder(url, -1);
            data = data.Replace("\\", "");
            data = "[" + data.Remove(0, 3);
            data = data.Remove(data.Length - 2, 2) + "]";

            var OrderList = (List<Order>)JsonConvert.DeserializeObject(data, (typeof(List<Order>)));
            dt.Rows.Clear();
            foreach (var order in OrderList)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = order.Person.Name;
                dr["Address"] = order.Person.Address;
                dr["amount"] = order.Amount;
                dr["Date"] = order.Date;
                dr["Total"] = TotalSum(order.Amount);
                dt.Rows.Add(dr);
            }
            dtOrders.Columns.Clear();
            dtOrders.ItemsSource = dt.DefaultView;
            dtOrders.AutoGenerateColumns = true;
            dtOrders.CanUserAddRows = false;

        }


        private double TotalSum(int amount)
        {
            return Math.Round(amount * 98.99 - (amount * 98.99 * Discounter(amount) / 100), 2);
        }

        private int Discounter(int amount)
        {
            int disc = 0;
            if (amount >= 50) { disc = 15; }
            else if (amount >= 10) { disc = 5; }
            return disc;
        }
    }
}
