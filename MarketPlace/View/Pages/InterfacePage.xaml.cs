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
    /// Логика взаимодействия для InterfacePage.xaml
    /// </summary>
    public partial class InterfacePage : Page
    {
        public InterfacePage()
        {
            InitializeComponent();
        }
        private void ProductBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new ProductPage());
        }

        private void BasketBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new BasketPage());

        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new ClientHomePage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
