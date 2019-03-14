using Lab01Khomenko.Views;
using Lab01Khomenko.Windows;
using System;

namespace Lab01Khomenko.Models
{
    class NavigationModel
    {
        private ContentWindow _contentWindow;
        private LoginView _loginView;
        private MainView _mainView;

        public NavigationModel(ContentWindow contentWindow, Storage storage)
        {
            _contentWindow = contentWindow;
            _loginView = new LoginView(storage);
            _mainView = new MainView(storage);
        }
        public void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Login:
                   _contentWindow.ContentControl.Content = _loginView;
                    break;
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
    public enum ModesEnum
    {
        Login,
        Main
    }

}
