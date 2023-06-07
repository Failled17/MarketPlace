using MarketPlace.Model;
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

namespace MarketPlace.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public BasketPage()
        {
            InitializeComponent();
            TypedeliveryCb.ItemsSource = App.db.DeliveryType.ToList();
            DeliveryPointCb.ItemsSource = App.db.DeliveryPoint.ToList();
            CheckCb.ItemsSource = App.db.Chek.Where(x => x.UserId == HelpClass.AutoUset.Id).ToList();
            TypePaymentCb.ItemsSource = App.db.TypePayment.ToList();



            CheckCb.ItemsSource = App.db.Chek.ToList();

            ProductLw.ItemsSource = HelpClass.prod;

            UserTb.Text = HelpClass.AutoUset.LastName + " " + HelpClass.AutoUset.Name + " " + HelpClass.AutoUset.SurName;
        }

        private void Typedelivery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int v = (TypedeliveryCb.SelectedItem as DeliveryType).Id;
            if (v == 1)
            {
                AdressSt.Visibility = Visibility.Collapsed;
                DeliveryPointSt.Visibility = Visibility.Visible;
            }
            else if (v == 2)
            {
                AdressSt.Visibility = Visibility.Visible;
                DeliveryPointSt.Visibility = Visibility.Collapsed;
            }
        }

        private void CheckCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chek = CheckCb.SelectedItem as Chek;
            CheckTb.Text = chek.Numger.ToString();
            BankTb.Text = chek.Bank.Title.ToString();


        }

        private void OrderAddBtn_Click(object sender, RoutedEventArgs e)
        {
            var chek = CheckCb.SelectedItem as Chek;
            var csv = chek.CSV.ToString();
            decimal summa;
            if (csv == CSV.Text.Trim())
            {


                Order orderuser = new Order
                {
                    Date = DateTime.Now,
                    Useer = HelpClass.AutoUset,
                    //  DateEnd = DateTime.Now + 3,
                    TypePayment = TypePaymentCb.SelectedItem as TypePayment,
                    DeliveryType = TypedeliveryCb.SelectedItem as DeliveryType,
                    AdressDelivery = AdressDeliveryTb.Text.Trim(),
                    DeliveryPoint = DeliveryPointCb.SelectedItem as DeliveryPoint,
                    Check = CheckTb.Text.Trim(),
                };

                var random = new Random();
                string randinstring = new string(Enumerable.Repeat("123456789", 13).Select(s => s[random.Next(s.Length)]).ToArray());
                App.db.Order.Add(orderuser);

                orderuser.Sum = HelpClass.prod.Sum(x => x.Count * x.Cost);


                foreach (Product product in HelpClass.prod)
                {
                    App.db.ProductOrder.Add(new ProductOrder
                    {
                        Order = orderuser,
                        BarCode = Convert.ToString(randinstring),
                        Product = product,
                        StatysOrderId = 1,
                        Quantity = product.Count,

                    });
                    //var sums = product.count * product.Cost;
                    //  summa = (decimal)sums;
                }
                //  orderuser.Sum  =


                MessageBox.Show("yes");
                App.db.SaveChanges();
            }
            else MessageBox.Show("csv не совпадают, проверьте");
        }

        private void TypePaymentCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int v = (TypePaymentCb.SelectedItem as TypePayment).Id;
            if (v == 1)
            {
                ChekSt.Visibility = Visibility.Visible;
                ChekRB.Visibility = Visibility.Visible;
                CheckCb.Visibility = Visibility.Visible;
            }
            else
            {
                ChekSt.Visibility = Visibility.Collapsed;
                ChekRB.Visibility = Visibility.Collapsed;
                CheckCb.Visibility = Visibility.Collapsed;
            }

        }

        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
