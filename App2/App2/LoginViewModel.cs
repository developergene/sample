using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2
{
    public class LoginViewModel : BaseViewModel
    {

        private readonly ICommand _loginCommand;


        public LoginViewModel()
        {
            _loginCommand = new Command(LoginEmailSignIn);
        }

        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        public string Username
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue<string>(value);
                if (value != "")
                    IsLoginEnabled = true;
            }
        }

        private bool _isEnabled;
        public bool IsLoginEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged("IsLoginEnabled");
            }
        }


        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand;
            }
        }

        public async void LoginEmailSignIn(object args)
        {
            
        }
    }
}
