using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using AppChambitasV1.Models;
using AppChambitasV1.Services;
using Xamarin.Forms;

namespace AppChambitasV1.ViewModels
{
    public class TecnicosViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Attributes
        List<Tecnicos> tecnicos;
        ObservableCollection<Tecnicos> _tecnicos;
        bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<Tecnicos> Tecnicos
        {
            get
            {
                return _tecnicos;
            }
            set
            {
                if (_tecnicos != value)
                {
                    _tecnicos = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Tecnicos)));
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

        #region Constructor
        public TecnicosViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();

            LoadTecnicos();
        }
        #endregion

        #region Methods
        async void LoadTecnicos()
        {
            IsRefreshing = true;
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage("Error",
                                                connection.Message);
                return;
            }
            else
            {
                var mainViewModel = MainViewModel.GetInstance();

                var urlAPI = Application.Current.Resources["URLAPI"].ToString();

                var response = await apiService.GetList<Tecnicos>(
                    urlAPI,
                    "/api",
                    "/Tecnicos",
                    mainViewModel.Token.TokenType,
                    mainViewModel.Token.AccessToken);

                if (!response.IsSuccess)
                {
                    await dialogService.ShowMessage(
                        "Error",
                        response.Message);
                    return;
                }

                tecnicos = (List<Tecnicos>)response.Result;
                Tecnicos = new ObservableCollection<Tecnicos>(
                    tecnicos.OrderBy(ts => ts.Tecn_Nombre));
            }

            IsRefreshing = false;
        }

        #endregion
    }
}