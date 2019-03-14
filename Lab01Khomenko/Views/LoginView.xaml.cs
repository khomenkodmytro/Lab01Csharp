using Lab01Khomenko.Models;
using Lab01Khomenko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab01Khomenko.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoginViewModel _viewModel;

        public LoginView(Storage storage)
        {
            InitializeComponent();
            _viewModel = new LoginViewModel(storage);
            DataContext = _viewModel;
        }
    }
}
