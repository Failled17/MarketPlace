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
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        public Order contextOrder;
        public EditOrderPage()
        {
            InitializeComponent();
            DeliveryTypeCb.ItemsSource = App.db.DeliveryType.ToList();
            TypePaymentCb.ItemsSource = App.db.TypePayment.ToList();
            UserCb.ItemsSource = App.db.Useer.ToList();
            DeliveryPointCb.ItemsSource = App.db.DeliveryPoint.ToList();
            List<StatysOrder> statys = App.db.StatysOrder.ToList();

            contextOrder = orders;
            DataContext = contextOrder;
            ProductLw.ItemsSource = App.db.ProductOrder.Where(x => x.OrderId == contextOrder.Id).ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var pro = (sender as Button).DataContext as ProductOrder;
            new EditStatusProductPage(pro).Show();
        }
    }
}
