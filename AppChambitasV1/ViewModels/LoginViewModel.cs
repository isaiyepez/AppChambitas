namespace AppChambitasV1.ViewModels
{    
    using System.ComponentModel;
    using System.Windows.Input;
    using AppChambitasV1.Services;
    using AppChambitasV1.Views;
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
            //Como los botones se habilitan con un booleano, es necesario habilitarlos
            IsEnabled = true;
            IsToggled = true;

        }
        #endregion

        #region Commands
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

            var response = await apiService.GetToken("http://appchambitasv1api2018.azurewebsites.net", Email, Password);

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

            await dialogService.ShowMessage("Sucessfull","Welcome, login successful");

            //Se implementa patrón singleton
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Categories = new CategoriesViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(
                new CategoriesView());
            
            Email = null;
            Password = null;

            //Si todo sale bien, deshabilita indicador, habilita botón
            IsRunning = false;
            IsEnabled = true;
        }

        #endregion

    }
}
