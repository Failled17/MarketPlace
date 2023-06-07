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
    /// Логика взаимодействия для UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();
        }
        public void Reshre()
        {
            UserDt.ItemsSource = App.db.Useer.ToList();
        }
        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as User;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.db.Useer.Remove(em);
            App.db.SaveChanges();
            Reshre();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new AddUserWindow(new User()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshre();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var users = (sender as Button).DataContext as User;
            var dialog = new AddUserWindow(users).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshre();
            Reshre();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshre();
        }
    }
}
