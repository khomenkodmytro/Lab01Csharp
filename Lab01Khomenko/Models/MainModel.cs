using Lab01Khomenko.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01Khomenko.Models
{
    class MainModel
    {
        private readonly Storage _storage;
        public event Action<Info> UInfoChanged;

        public MainModel (Storage storage)
        {
            _storage = storage;
            storage.InfoChanged += OnInfoChanged;
        
        }

        private void OnInfoChanged(Info info)
        {
            UInfoChanged?.Invoke(info);
        }
        public void ShowFirstWindow()
        {
            NavigationManager.Instance.Navigate(ModesEnum.Login);
        }
    }
}
