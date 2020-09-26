using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCompHAS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageView : ContentPage
    {
        public Models.MenuItem[] OpcoesMenu { get; set; }

        public ListView ListView { get; set; }

        public void DefinirMenu()
        {
            OpcoesMenu = new[]
            {
                new Models.MenuItem
                {
                    Id = 0, Title = "Participantes",
                    TargetType = typeof(Views.Participantes.ListagemView),
                    IconSource = "MenuParticipantes.png"
                },
                new Models.MenuItem
                {
                    Id = 0, Title = "Compromissos",
                    TargetType = typeof(Views.Compromissos.ListagemView),
                    IconSource = "MenuCompromissos.png"

                },
                new Models.MenuItem
                {
                    Id = 1, Title = "Imagens ",
                    TargetType = typeof(Views.Imagens.ListagemView),
                    IconSource = "MenuImagens.png"

                }
            };
        }
        public MasterPageView()
        {
            InitializeComponent();

            DefinirMenu();
            ListView = itensMenuListView;
            BindingContext = this;
        }

        public string Nome
        {
            get
            {
                string nome = string.Empty;

                if (Application.Current.Properties.ContainsKey("UsuarioNome"))
                    nome = Application.Current.Properties["UsuarioNome"].ToString();

                return string.Format("Usuario: {0}", nome);
            }
        }

        public string Email
        {
            get
            {
                string email = string.Empty;

                if (Application.Current.Properties.ContainsKey("UsuarioEmail"))
                    email = Application.Current.Properties["UsuarioEmail"].ToString();

                return string.Format("Email:  {0}", email);
            }
        }
    }
}