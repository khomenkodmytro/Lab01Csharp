using Lab01Khomenko.Models;
using Lab01Khomenko.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab01Khomenko.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public LoginModel LModel { get; private set; }
        private ICommand _loginCommand;
        private DateTime _birthDate;

        

        public LoginViewModel(Storage storage)
        {
            LModel = new LoginModel(storage);
            BirthDate = DateTime.Today.Date;
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                InvokePropertyChanged("BirthDate");
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand<object>(LoginExecute, LoginCanExecute);
                }

                return _loginCommand;
            }
            set {
                _loginCommand = value;
                
            }
        }

        private bool LoginCanExecute(object obj)
        {
            return true;
        }

        private void LoginExecute(object obj)
        {
            LModel.CheckDate(Date);
        }
        public DateTime Date
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    InvokePropertyChanged("Date");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }
    }
}
