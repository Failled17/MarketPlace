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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ProdLw.ItemsSource = App.db.Product.ToList();
        }

        private void InformationBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            NavigationService.Navigate(new InfoPage(prod));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as Product;
            HelpClass.prod.Add(product);
        }

        private void AddBtn_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InfoPage(new Product()));
        }

        private void ProductInformationBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            NavigationService.Navigate(new ProductInformationPage(prod));
        }
    }
}
