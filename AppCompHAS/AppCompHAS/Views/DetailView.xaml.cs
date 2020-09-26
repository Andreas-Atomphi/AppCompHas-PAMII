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
    public partial class DetailView : MasterDetailPage
    {
        public DetailView()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += ListView_ItemSelected;
            IsPresented = true;

            var navigationPage = new Xamarin.Forms.NavigationPage(new MainPage());

            this.Detail = navigationPage;

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Models.MenuItem;

            if (item == null)
                return;

            var page = (Xamarin.Forms.Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Detail = new Xamarin.Forms.NavigationPage(page);

            IsPresented = false;
            masterPage.ListView.SelectedItem = null;
        }

       
    }
}