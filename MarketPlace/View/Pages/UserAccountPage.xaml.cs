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
    /// Логика взаимодействия для UserAccountPage.xaml
    /// </summary>
    public partial class UserAccountPage : Page
    {
        public byte[] image;
        public User contextuser;
        public UserAccountPage()
        {
            InitializeComponent();
        }
        public void Refresh()
        {
            contextuser = HelpClass.AutoUset;
            ChekLw.ItemsSource = App.db.Chek.Where(x => x.UserId == contextuser.Id).ToList();

        }

        private void EditInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            new EditInfoProvPage(contextuser).ShowDialog();
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddChek(new Chek()).ShowDialog();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var ch = (sender as Button).DataContext as Chek;
            new AddChek(ch).ShowDialog();
        }

        private void InfoOrrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as ProductOrder;
            var dialo = new InfoOrderHomePage(prod).ShowDialog();
            if (dialo.HasValue && dialo.Value)
                Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
