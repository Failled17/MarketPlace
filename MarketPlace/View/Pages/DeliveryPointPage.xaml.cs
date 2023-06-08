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
    /// Логика взаимодействия для DeliveryPointPage.xaml
    /// </summary>
    public partial class DeliveryPointPage : Page
    {
        public DeliveryPointPage()
        {
            InitializeComponent();
            DeliveryPointDt.ItemsSource = App.db.DeliveryPoint.ToList();
        }

        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDelivetyPointPage(new DeliveryPoint()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }

        public void Reshres()
        {
            DeliveryPointDt.ItemsSource = App.db.DeliveryPoint.ToList();
        }
        private void DeletDeliveryPointBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as DeliveryPoint;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.db.DeliveryPoint.Remove(em);
            App.db.SaveChanges();
            Reshres();
        }

        private void EditDelivpointBtn_Click(object sender, RoutedEventArgs e)
        {
            var point = (sender as Button).DataContext as DeliveryPoint;
            var dialog = new AdDelivetyPointPage(point).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();

        }
    }
}
