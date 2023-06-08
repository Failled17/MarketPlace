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
    /// Логика взаимодействия для EditStatusWin.xaml
    /// </summary>
    public partial class EditStatusWin : Window
    {
        public ProductOrder contextProductOrder;
        public EditStatusWin(ProductOrder productorders)
        {
            InitializeComponent();
            StatusCb.ItemsSource = App.db.StatysOrder.ToList();
            contextProductOrder = productorders;
            DataContext = contextProductOrder;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("saved");
            App.db.SaveChanges();
            Close();

        }
    }
}
