﻿using ClientApp.ViewModel;
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

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ICommand ButtonCommand { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ButtonCommand = new RelayCommand(ShowMessage, param => true);
 
        }

        private void ShowMessage(object sender)
        {
            MessageBox.Show(sender.ToString());
        }


        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            
            SocketNp.SynchronousSocketClient.StartClient(this.TextBoxName.Text, this.TextBoxPassword.Text);

        }
    }
}
