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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");

            var db = new SQLiteConnection(dbPath);
            var myquery = db.Table<UserTable>().Where(u => u.VergiNumarası.Equals(vergiNo.Text) && u.KullanıcıAdı.Equals(userName.Text)
                && u.Şifre.Equals(userPassword.Text)).FirstOrDefault();

            if (myquery != null)
            {
                App.Current.MainPage = new MainPage();
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Hata", "Yanlış Kullanıcı Adı veya Şifre", "Yeniden Dene", "İptal");

                    if (result)
                        await Navigation.PushAsync(new MainPage());
                    else
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }

                });

            }





        }

        private void CheckBoxRememberMe_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }
    }
}