﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> PropertyValues = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            return GetValue(propertyName, default(T));
        }

        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName)) return;

            var shouldNotify = !PropertyValues.ContainsKey(propertyName) || !object.Equals(value, PropertyValues[propertyName]);

            PropertyValues[propertyName] = value;

            if (shouldNotify)
                RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// Gets the value of the property specified by propertyName. If no
        /// value is present, defaultValue is returned.
        /// </summary>
        /// <param name="propertyName">The name of the property for which you're
        /// trying to get the value of.</param>
        /// <param name="propertyName">The name of the property (note this is case sensitive)
        /// for which you're trying to get the value of</param>
        private T GetValue<T>(string propertyName, T defaultValue)
        {
            if (PropertyValues.ContainsKey(propertyName))
                return (T)PropertyValues[propertyName];

            return defaultValue;
        }

        public virtual void RaisePropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        private bool _isError;
        public bool IsError
        {
            get { return _isError; }
            set
            {
                _isError = value;
                RaisePropertyChanged("IsError");
            }
        }
    }
}
