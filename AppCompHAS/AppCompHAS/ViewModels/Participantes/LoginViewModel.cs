using AppCompHAS.Models;
using AppCompHAS.Servicos.Participantes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCompHAS.ViewModels.Participantes
{
    public class LoginViewModel : BaseViewModel
    {
        public  ICommand EntrarCommand { get; set; }
        private Participante Usuario;
        private ParticipanteService pService = new ParticipanteService();

        public async Task ConsultarUsuario()
        {
            Participante p = null;
            p = await pService.PostLoginParticipanteAsync(Usuario);
            MessagingCenter.Send<Participante>(p, "InformacaoCRUD");
        }

        private void RegistrarCommands()
        {
            EntrarCommand = new Command(async () =>
            {
                await ConsultarUsuario();
            });

        }

        public LoginViewModel()
        {
            this.Usuario = new Participante();
            RegistrarCommands();
        }

        public string Login
        {
            get { return this.Usuario.Email; }
            set
            {
                this.Usuario.Email = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return this.Usuario.Cpf; }
            set
            {
                this.Usuario.Cpf = value;
                OnPropertyChanged();
            }
        }
    }
}

   

    
