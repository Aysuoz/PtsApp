using PersonelTakip.Views;
using PersonelTakip;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonelTakip.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {


        public SignUpPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<UserTable>();

            var item = new UserTable()
            {
                VergiNumarası = vergiNo.Text,
                KullanıcıAdı = userName.Text,
                Şifre = userPassword.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("", "Kayıt Başarılı", "Devam", "İptal");

                if (result)
                    App.Current.MainPage = new LoginPage();
            });
        }
    }
}