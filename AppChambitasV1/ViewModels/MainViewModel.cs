using System;
using System.Collections.ObjectModel;
using AppChambitasV1.Models;
using Xamarin.Forms;

namespace AppChambitasV1.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<Menu> MyMenu
        {
            get;
            set;
        }
        public LoginViewModel Login
        {
            get;
            set;
        }

        public CategoriesViewModel Categories
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;

        }

        public TiposServiciosDetalleViewModel TiposServiciosDetalle
        {
            get;
            set;
        }

        public TecnicosViewModel Tecnicos
        {
            get;
            set;
        }

        public NewCustomerViewModel NewCustomer
        {
            get;
            set;
        }

        public UbicationsViewModel Ubications
        {
            get;
            set;
        }

        public MyProfileViewModel MyProfile
        {
            get;
            set;
        }

        public PasswordRecoveryViewModel PasswordRecovery
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();
            LoadMenu();
        }


        #endregion

        #region Singleton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }

        #endregion

        #region Methods
        public void RegisterDevice()
        {
            var register = DependencyService.Get<IRegisterDevice>();
            register.RegisterDevice();
        }

        private void LoadMenu()
        {
            MyMenu = new ObservableCollection<Menu>();

            MyMenu.Add(new Menu
            {
                Icon = "ic_settings",
                PageName = "MyProfileView",
                Title = "My Profile",
            });

            MyMenu.Add(new Menu
            {
                Icon = "ic_map",
                PageName = "UbicationsView",
                Title = "Ubications",
            });

            //MyMenu.Add(new Menu
            //{
            //    Icon = "ic_sync",
            //    PageName = "SyncView",
            //    Title = "Sync Offline Operations",
            //});

            MyMenu.Add(new Menu
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginView",
                Title = "Close sesion",
            });
        }
        #endregion
    }
}
