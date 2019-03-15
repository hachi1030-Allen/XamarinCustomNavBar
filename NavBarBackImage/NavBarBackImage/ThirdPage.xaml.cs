using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavBarBackImage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdPage : ContentPage, INavigationActionBarConfig
    {
        //public int BackButtonStyle { get; set; }
        public ThirdPage()
        {
            InitializeComponent();
        }
    }
}