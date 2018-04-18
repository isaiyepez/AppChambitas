﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AppChambitasV1.Models;
using AppChambitasV1.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
namespace AppChambitasV1.ViewModels
{
    public class UbicationsViewModel
    {
        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Properties
        public ObservableCollection<Pin> Pins
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public UbicationsViewModel()
        {
            instance = this;

            apiService = new ApiService();
            dialogService = new DialogService();
        }
        #endregion

        #region Sigleton
        static UbicationsViewModel instance;

        public static UbicationsViewModel GetInstance()
        {
            if (instance == null)
            {
                return new UbicationsViewModel();
            }

            return instance;
        }
        #endregion

        #region Methods
        public async Task LoadPins()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var urlAPI = Application.Current.Resources["URLAPI"].ToString();

            var response = await apiService.GetList<Ubication>(
                urlAPI,
                "/api",
                "/Ubications",
                mainViewModel.Token.TokenType,
                mainViewModel.Token.AccessToken);

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                    response.Message);
                return;
            }

            var ubications = (List<Ubication>)response.Result;
            Pins = new ObservableCollection<Pin>();
            foreach (var ubication in ubications)
            {
                Pins.Add(new Pin
                {
                    Address = ubication.Address,
                    Label = ubication.Description,
                    Position = new Position(
                        ubication.Latitude,
                        ubication.Longitude),
                    Type = PinType.Place,
                });
            }
        }
        #endregion
    }
}
