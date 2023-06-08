using MarketPlace.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
using static System.Net.Mime.MediaTypeNames;

namespace MarketPlace.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddImageWin.xaml
    /// </summary>
    public partial class AddImageWin : Window
    {
        public User contextuser;
        public byte[] image;
        public AddImageWin()
        {
            InitializeComponent();
            contextuser = user;
            DataContext = user;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfil = new OpenFileDialog();

            if (openfil.ShowDialog().GetValueOrDefault())
            {
                image = File.ReadAllBytes(openfil.FileName);
                ImageProf.Source = new BitmapImage(new Uri(openfil.FileName));
            }
            contextuser.Photo = image;
            MessageBox.Show("image saved");
            App.db.SaveChanges();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
