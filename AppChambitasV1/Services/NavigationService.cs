using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppChambitasV1.Views;

namespace AppChambitasV1.Services
{
    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch(pageName)
            {
                case "CategoriesView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                new CategoriesView());
                    break;                
            }

        }
    }
}
