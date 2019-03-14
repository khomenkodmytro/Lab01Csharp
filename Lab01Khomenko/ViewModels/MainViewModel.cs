﻿//gg
using Lab01Khomenko.Models;
using Lab01Khomenko.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab01Khomenko.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainModel MModel { get; private set; }
        private int _age;
        private string _westernZodiac;
        private string _chineseZodiac;
        private Visibility _birthdayVisib;

        private ICommand _backCommand;
        public MainViewModel(Storage storage)
        {
            MModel = new MainModel(storage);
            MModel.UInfoChanged += UIOnDateChanged;
        }
        private void UIOnDateChanged(Info info)
        {
            Age = info.Age;
            WesternZodiac = info.WesternZodiac;
            ChineseZodiac = info.ChineseZodiac;
            BirthdayVisib = info.isBirthdayToday ? Visibility.Visible : Visibility.Collapsed;
        }
        public Visibility BirthdayVisib
        {
            get { return _birthdayVisib; }
            set
            {
                if (_birthdayVisib != value)
                {
                    _birthdayVisib = value;
                    InvokePropertyChanged("BirthdayVisib");
                }
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    InvokePropertyChanged("Age");
                    
                }
            }
        }
        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                if (_westernZodiac!=value)
                {
                    _westernZodiac = value;
                    InvokePropertyChanged("WesternZodiac");
                }
            }
        }
        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                if (_chineseZodiac != value)
                {
                    _chineseZodiac = value;
                    InvokePropertyChanged("ChineseZodiac");
                }
            }
        }
        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new RelayCommand<object>(BackExecute, BackCanExecute);
                }
                return _backCommand;
            }
            set
            {
                _backCommand = value;
                InvokePropertyChanged("BackCommand");
            }
        }
        private void BackExecute(object obj)
        {
            MModel.ShowFirstWindow();
        }

        private bool BackCanExecute(object obj)
        {
            return true;
        }
        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
