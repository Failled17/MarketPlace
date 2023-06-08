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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public RolePage()
        {
            InitializeComponent();
        }
        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as Role;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.db.Role.Remove(em);
            App.db.SaveChanges();
            Reshres();

        }

        public void Reshres()
        {
            RoleDt.ItemsSource = App.db.Role.ToList();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var rol = (sender as Button).DataContext as Role;
            var dialog = new AddRoleWindows(rol).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new AddRoleWindows(new Role()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }
    }
}
