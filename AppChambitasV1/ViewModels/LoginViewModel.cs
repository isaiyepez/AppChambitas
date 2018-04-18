﻿namespace AppChambitasV1.ViewModels
{    
    using System.ComponentModel;
    using System.Windows.Input;
    using AppChambitasV1.Services;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        ApiService apiService;
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Attributes
        string _email;
        string _password;
        bool _isToggled;
        bool _isRunning;
        bool _isEnabled;
        #endregion

        #region Properties
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }
        public bool IsToggled
        {
            get
            {
                return _isToggled;
            }
            set
            {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsToggled)));
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();
            //Como los botones se habilitan con un booleano, es necesario habilitarlos
            IsEnabled = true;
            IsToggled = true;

        }
        #endregion

        #region Commands
        //public ICommand RecoverPasswordCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(RecoverPassword);
        //    }
        //}

        //async void RecoverPassword()
        //{
        //    MainViewModel.GetInstance().PasswordRecovery =
        //        new PasswordRecoveryViewModel();
        //    await navigationService.NavigateOnLogin("PasswordRecoveryView");
        //}


        public ICommand LoginWithFacebookCommand
        {
            get
            {
                return new RelayCommand(LoginWithFacebook);
            }
        }

        async void LoginWithFacebook()
        {
            await navigationService.NavigateOnLogin("LoginFacebookView");
        }

        public ICommand RegisterNewUserCommand
        {
            get
            {
                return new RelayCommand(RegisterNewUser);
            }
        }

        async void RegisterNewUser()
        {
            MainViewModel.GetInstance().NewCustomer = new NewCustomerViewModel();
            await navigationService.NavigateOnLogin("NewCustomerView");
        }


        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }

        }

        async void Login()
        {
            if(string.IsNullOrEmpty(Email))
            {
                await dialogService.ShowMessage(
                    "Error", 
                    "You must enter an Email");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "You must enter a Password");
                return;
            }

            //Se activa el indicator y se deshabilitan los botones
            IsRunning = true;
            IsEnabled = false;

            //Validar si hay internet
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                //Si falla la conexión, se rehabilitan los botones
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var urlAPI = Application.Current.Resources["URLAPI"].ToString();

            var response = await apiService.GetToken(
                urlAPI,
                Email, 
                Password);

            //Si se perdió la conexión a la mitad de la operación...
            if (response == null)
            {
                //Si no se recibe un token, se desactiva el indicador y se rehabilita el botón
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", "The service is not available, please try again");
                Password = null;
                return;
            }

            if (string.IsNullOrEmpty(response.AccessToken))
            {
                //Si no se recibe un token, se desactiva el indicador y se rehabilita el botón
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", response.ErrorDescription);
                Password = null;
                return;
            }

            await dialogService.ShowMessage("Sucessful","Welcome, login successful");

            //Se implementa patrón singleton
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = response;
            mainViewModel.Categories = new CategoriesViewModel();
            navigationService.SetMainPage("MasterView");
                                   
            Email = null;
            Password = null;

            //Si todo sale bien, deshabilita indicador, habilita botón
            IsRunning = false;
            IsEnabled = true;
        }

        #endregion

    }
}
