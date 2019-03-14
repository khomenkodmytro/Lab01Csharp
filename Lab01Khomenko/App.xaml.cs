using Lab01Khomenko.Manager;
using Lab01Khomenko.Models;
using Lab01Khomenko.Windows;
using System.Windows;

namespace Lab01Khomenko
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Storage storage = new Storage();

            ContentWindow contentWindow = new ContentWindow();
            NavigationModel navigationModel = new NavigationModel(contentWindow, storage);
            NavigationManager.Instance.Initialize(navigationModel);
            contentWindow.Show();
            navigationModel.Navigate(ModesEnum.Login);
        }
    }
}
