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
    /// Логика взаимодействия для AddProviderWin.xaml
    /// </summary>
    public partial class AddProviderWin : Window
    {
        public Provider contextProvider;
        DbPropertyValues values;
        public AddProviderWin()
        {
            InitializeComponent();
            contextProvider = provider;
            DataContext = contextProvider;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTb.Text.Trim().Length > 0 && AdressTb.Text.Trim().Length > 0)
            {
                if (contextProvider.Id == 0)
                {
                    App.db.Provider.Add(contextProvider);
                }
                MessageBox.Show("yes");
                App.db.SaveChanges();

            }
            else MessageBox.Show("Fill in the name and address");
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
