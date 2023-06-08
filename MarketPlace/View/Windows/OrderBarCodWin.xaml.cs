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
using System.Windows.Shapes;

namespace MarketPlace.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderBarCodWin.xaml
    /// </summary>
    public partial class OrderBarCodWin : Window
    {
        public ProductOrder contextproductOrder;
        public OrderBarCodWin()
        {
            InitializeComponent();
        }
        private void ExtraditeBtn_Click(object sender, RoutedEventArgs e)
        {
            var barcoderTb = BarCodeTb.Text.Trim();
            var barcode = App.db.ProductOrder.Where(x => x.BarCode == barcoderTb && x.StatysOrderId == 5).FirstOrDefault();
            barcode.StatysOrderId = 8;
            App.db.SaveChanges();
            MessageBox.Show($"order {barcode.StatysOrder.Title}");
            Close();
        }

        private void BarCodeTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void BarCodeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var barcoderTb = BarCodeTb.Text.Trim();
            var barcode = App.db.ProductOrder.Where(x => x.BarCode == barcoderTb && x.StatysOrderId == 5).FirstOrDefault();


            if (barcode != null)
            {
                NumberTb.Text = barcode.Order.Id.ToString();
                ProductTb.Text = barcode.Product.Title.ToString();
                StatysTb.Text = barcode.StatysOrder.Title.ToString();

            }
            else
            {
                var statc = App.db.ProductOrder.Where(x => x.BarCode == barcoderTb).FirstOrDefault().StatysOrder.Title.ToString();
                MessageBox.Show($" Заказ имеет статус {statc}");
            }


        }
    }
}
