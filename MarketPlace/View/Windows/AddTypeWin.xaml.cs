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
    /// Логика взаимодействия для AddTypeWin.xaml
    /// </summary>
    public partial class AddTypeWin : Window
    {
        public TypeProduct contextTypeProduct;
        public AddTypeWin(TypeProduct typeproduct)
        {
            InitializeComponent();
            contextTypeProduct = typeproduct;
            DataContext = contextTypeProduct;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTb.Text.Trim().Length > 0)
            {

                if (contextTypeProduct.Id == 0)
                {
                    App.db.TypeProduct.Add(contextTypeProduct);
                }
                MessageBox.Show("Type product saved");
                App.db.SaveChanges();

            }
            else MessageBox.Show("Fill in the title");
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }
    }
}
