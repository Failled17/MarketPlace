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
    /// Логика взаимодействия для TypePage.xaml
    /// </summary>
    public partial class TypePage : Page
    {
        public TypePage()
        {
            InitializeComponent();
            TypeProduct.ItemsSource = App.db.DeliveryType.ToList();
            Instance = this;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = (sender as Button).DataContext as DeliveryType;
            var dialogResult = new AddDeliveryPage(new DeliveryType()).ShowDialog();
            // var dialogResult = new AddDeliveryPage(type).ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
                Reshres();

        }



        public void Reshres()
        {
            TypeProduct.ItemsSource = App.db.DeliveryType.ToList();
        }



        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = (sender as Button).DataContext as DeliveryType;
            var dialogResult = new AddDeliveryPage(type).ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
                Reshres();

        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as DeliveryType;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.db.DeliveryType.Remove(em);
            App.db.SaveChanges();
            TypeProduct.ItemsSource = App.db.DeliveryType.ToList();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TypeProduct.Items.Refresh();
        }
    }
}
