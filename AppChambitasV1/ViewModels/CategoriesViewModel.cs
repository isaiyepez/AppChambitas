using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using AppChambitasV1.Models;
using AppChambitasV1.Services;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace AppChambitasV1.ViewModels
{
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Attributes
        ObservableCollection<TiposServicios> _tiposServicios;
        #endregion

        #region Properties
        public ObservableCollection<TiposServicios> TiposServicios
        {
            get
            {
                return _tiposServicios;
            }
            set
            {
                if (_tiposServicios != value)
                {
                    _tiposServicios = value;
                    PropertyChanged?.Invoke(
                    this,
                        new PropertyChangedEventArgs(nameof(TiposServicios)));
                }
            }
        }
        #endregion

        #region Constructors
        public CategoriesViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();

            LoadCategories();
        }
        #endregion

        #region Methods
        async void LoadCategories()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage("Error",
                                                connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var urlAPI = Application.Current.Resources["URLAPI"].ToString();

            var response = await apiService.GetList<TiposServicios>(
                urlAPI,
                "/api",
                "/TiposServicios",
                mainViewModel.Token.TokenType,
            mainViewModel.Token.AccessToken);

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error",
                                                response.Message);
                return;
            }
            var tiposServicios = (List<TiposServicios>)response.Result;
            TiposServicios = new ObservableCollection<TiposServicios>(tiposServicios.OrderBy(ts => ts.TipoServ_Nombre));
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadCategories);
            }
        }
        #endregion
    }
}
