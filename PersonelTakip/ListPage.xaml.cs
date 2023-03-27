using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonelTakip
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public static string EntryValue = "";

        private void EntryText1_TextChanged(object sender, TextChangedEventArgs e) { EntryValue = e.NewTextValue; }
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel();
        }


        
    }
}