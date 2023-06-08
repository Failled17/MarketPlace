using MarketPlace.Model;
using Microsoft.Win32;
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
    /// Логика взаимодействия для ProductInformationPage.xaml
    /// </summary>
    public partial class ProductInformationPage : Page
    {
        public Product contextproduct;
        public ProductInformationPage()
        {
            InitializeComponent();
            TypeCb.ItemsSource = App.db.TypeProduct.ToList();
            ProviderTb.ItemsSource = App.db.Provider.ToList();
            contextproduct = product;
            DataContext = contextproduct;
            ImageLW.ItemsSource = contextproduct.ProductPhoto.ToList();

            int id = Convert.ToInt32(contextproduct.Id);



            ImageLW.ItemsSource = contextproduct.ProductPhoto.ToList();

        }
        private void Reshres()
        {
            ImageLW.ItemsSource = contextproduct.ProductPhoto.ToList();
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            var dialor = new OpenFileDialog() { Multiselect = true };
            if (dialor.ShowDialog().GetValueOrDefault())
            {
                foreach (var item in dialor.FileNames)
                {
                    contextproduct.ProductPhoto.Add(new ProductPhoto()
                    {
                        Photo = File.ReadAllBytes(item),
                        Product = contextproduct,
                    });


                }
                Reshres();
                DataContext = null;
                DataContext = contextproduct;


            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (contextproduct.Id == 0)
            {
                App.db.Product.Add(contextproduct);
            }
            MessageBox.Show("yes");
            App.db.SaveChanges();
            NavigationService.Navigate(new ProductPage());
        }

        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsDigit(e.Text, 0) && (e.Text != ","))
            {
                e.Handled = true;
            }
        }
    }
}
