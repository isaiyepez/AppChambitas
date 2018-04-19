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
        List<TiposServicios> tiposServicios;
        ObservableCollection<TiposServicios> _tiposServicios;
        bool _isRefreshing;
        string _filter;
        #endregion

        #region Properties
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    Search();
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Filter)));
                }
            }
        }

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

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRefreshing)));
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
            tiposServicios = (List<TiposServicios>)response.Result;
            Search();
            IsRefreshing = false;
        }
        #endregion

        #region Commands

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        void Search()
        {
            IsRefreshing = true;

            if (string.IsNullOrEmpty(Filter))
            {
                TiposServicios = new ObservableCollection<TiposServicios>(
                    tiposServicios.OrderBy(c => c.TipoServ_Nombre));
            }
            else
            {
                TiposServicios = new ObservableCollection<TiposServicios>(tiposServicios
                    .Where(c => c.TipoServ_Nombre.ToLower().Contains(Filter.ToLower()))
                    .OrderBy(c => c.TipoServ_Nombre));
            }

            IsRefreshing = false;
        }
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
