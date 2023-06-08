using MarketPlace.Pages;
using MarketPlace.View.Windows;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutoPage());
        }

        private void ProductBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new ProductPage());
        }

        private void ProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new ProviderPage());
        }

        private void TypepProdBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new TypeProductPage());
        }

        private void BasketBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new BasketPage());
        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new UserAccountPage());
        }

        private void GivOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            new OrderBarCodWin().Show();
        }

        private void DeliveryBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new TypePage());
        }

        private void Orderbtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new OrderPage());
        }

        private void DeliveryPointBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new DeliveryPointPage());
        }

        private void RoleBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new RolePage());
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new UserPage());
        }
    }
}
