﻿using System;
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
    /// Логика взаимодействия для BankCardWin.xaml
    /// </summary>
    public partial class BankCardWin : Window
    {
        public Chek contextchek;
        public BankCardWin()
        {
            InitializeComponent();
            BankCb.ItemsSource = App.db.Bank.ToList();
            contextBankCard = BankCard;
            DataContext = contextchek;
            contextchek.UserId = HelpClass.AutoUset.Id;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextchek.Numger))
            {
                MessageBox.Show("Number is null");
                return;
            }
            else if (string.IsNullOrEmpty(contextchek.CSV))
            {
                MessageBox.Show("CSV is null");
                return;
            }
            else if (contextchek.Age == null)
            {
                MessageBox.Show("Date is null");
                return;
            }
            else if (contextchek.Bank == null)
            {
                MessageBox.Show("Bank is null");
                return;
            }
            else
            {
                if (contextchek.Id == 0)
                {
                    App.db.Chek.Add(contextchek);
                }
                MessageBox.Show("Chek saved");
                App.db.SaveChanges();
                DialogResult = true;

            }


        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
