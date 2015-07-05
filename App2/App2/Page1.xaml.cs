using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App2
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            BindingContext =new  LoginViewModel();
            InitializeComponent();
        }
    }
}
