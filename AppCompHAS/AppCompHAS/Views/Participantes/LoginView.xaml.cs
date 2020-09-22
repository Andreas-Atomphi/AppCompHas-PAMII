using AppCompHAS.Models;
using AppCompHAS.ViewModels.Participantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCompHAS.Views.Participantes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        LoginViewModel LoginViewModel;
        Participante p;
        public LoginView()
        {
            InitializeComponent();
            p = new Participante();
            LoginViewModel = new LoginViewModel();
            BindingContext = LoginViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Participante>(this, "InformacaoCRUD", async (p) =>
            {

                if (p.Id != 0)
                {
                    Application.Current.Properties["Usuario"] = p.Id;
                    Application.Current.Properties["UsuarioTipoId"] = p.TipoId;
                    Application.Current.Properties["UsuarioNome"] = p.Nome;
                    Application.Current.Properties["UsuarioEmail"] = p.Email;

                    string mensagem = string.Format("Bem Vindo, {0}!", p.Nome);
                    await DisplayAlert("Informação", mensagem, "OK");
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                    await DisplayAlert("Informação", "Dados incorretos!!! =(", "OK");
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }
    }
}