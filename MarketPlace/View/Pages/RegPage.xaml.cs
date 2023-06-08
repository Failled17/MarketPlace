using MarketPlace.Model;
using MarketPlace.Pages;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            string password2 = PasswordTb2.Password.Trim();
            if (login.Length > 0 && password.Length > 0 && password2.Length > 0)
            {
                if (password == password2)
                {
                    if (App.db.Useer.Local.Any(x => x.Login == login && x.Password == password && x.Password == password2))
                    {
                        MessageBox.Show("such user exists");
                    }
                    else
                    {
                        App.db.Useer.Add(new User
                        {
                            Password = password,
                            Login = login,
                            Name = NameTb.Text.Trim(),
                            LastName = LastNameTb.Text.Trim(),
                            SurName = SurnameTb.Text.Trim(),
                        });
                        App.db.SaveChanges();
                        MessageBox.Show("Welcome");
                        NavigationService.Navigate(new AuthPage());
                    }
                }
                else MessageBox.Show("Password mismatch");
            }
            else MessageBox.Show("fill in the fields");



        }
    }
}
