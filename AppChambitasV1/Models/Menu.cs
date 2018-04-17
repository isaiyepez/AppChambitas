using AppChambitasV1.Services;
using AppChambitasV1.ViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;


namespace AppChambitasV1.Models
{
    public class Menu
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region Properties
        public string Icon
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string PageName
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public Menu()
        {
            
            navigationService = new NavigationService();
        }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }
        #endregion

        #region Methods
        async void Navigate()
        {
            switch (PageName)
            {
                case "LoginView":
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.Token.IsRemembered = false;
                    //dataService.Update(mainViewModel.Token);
                    mainViewModel.Login = new LoginViewModel();
                    navigationService.SetMainPage(PageName);
                    break;
                case "UbicationsView":
                    MainViewModel.GetInstance().Ubications =
                        new UbicationsViewModel();
                    await navigationService.NavigateOnMaster(PageName);
                    break;               
                case "MyProfileView":
                    MainViewModel.GetInstance().MyProfile =
                        new MyProfileViewModel();
                    await navigationService.NavigateOnMaster(PageName);
                    break;
            }
        }
        #endregion
    }
}
