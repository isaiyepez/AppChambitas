namespace AppChambitasV1
{
    using System;
    using AppChambitasV1.Models;
    using AppChambitasV1.Services;
    using AppChambitasV1.ViewModels;
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Properties
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }
        public static MasterView Master
        {
            get;
            internal set;
        }
        #endregion

		public App()
        {
            InitializeComponent();

            apiService = new ApiService();
            dialogService = new DialogService();
            MainPage = new NavigationPage(new LoginView());
            //MainPage = new MasterView();
        }

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static Action LoginFacebookFail
        {
            get
            {
                return new Action(() => Current.MainPage =
                                  new NavigationPage(new LoginView()));
            }
        }

        public async static void LoginFacebookSuccess(FacebookResponse profile)
        {
            if (profile == null)
            {
                Current.MainPage = new NavigationPage(new LoginView());
                return;
            }

            var apiService = new ApiService();
            var dialogService = new DialogService();

            var checkConnetion = await apiService.CheckConnection();
            if (!checkConnetion.IsSuccess)
            {
                await dialogService.ShowMessage("Error", checkConnetion.Message);
                return;
            }

            var urlAPI = Application.Current.Resources["URLAPI"].ToString();
            var token = await apiService.LoginFacebook(
                urlAPI,
                "/api",
                "/Customers/LoginFacebook",
                profile);

            if (token == null)
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Problem ocurred retrieving user information, try latter.");
                Current.MainPage = new NavigationPage(new LoginView());
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            //mainViewModel.RegisterDevice();
            mainViewModel.Categories = new CategoriesViewModel();
            Current.MainPage = new MasterView();
        }
        #endregion
    }
}
