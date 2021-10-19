using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpaceDonkey.Mvvm.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            Test2.PropertyChanged += Test_PropertyChanged;
        }

        private void Test_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsVisible")
            {
                Debug.WriteLine($"GOTCHA! {Test2.IsVisible}");
            }
            else
                Debug.WriteLine(e.PropertyName);

        }
    }
}