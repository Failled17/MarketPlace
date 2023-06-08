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
    /// Логика взаимодействия для AllPage.xaml
    /// </summary>
    
    public partial class AllPage : Page
    {
        public AllPage()
        {   
            InitializeComponent();
            contextproduct = product;
            DataContext = contextproduct;
            ImageLW.ItemsSource = App.db.ProductPhoto.Where(x => x.ProductId == contextproduct.Id).ToList();
            //ProviderTb.Text = contextproduct.Provider.Title;
            //TypeCb.Text = contextproduct.TypeProduct.Title;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage());
        }
    }
}
