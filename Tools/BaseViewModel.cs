﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.ProgrammingInCSharp2019.Practice3.LoginControlMVVM.Properties;

namespace lab2_cs.Tools
{
    internal abstract class BaseViewModel:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
