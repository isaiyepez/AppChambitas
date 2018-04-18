﻿
using System.Threading.Tasks;
using AppChambitasV1.Services;
using AppChambitasV1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
namespace AppChambitasV1.Views
{
    public partial class UbicationsView : ContentPage
    {
        #region Services
        GeolocatorService geolocatorService;
        #endregion

        #region Constructors
        public UbicationsView()
        {
            InitializeComponent();

            geolocatorService = new GeolocatorService();

            MoveMapToCurrentPosition();
        }
        #endregion

        #region Methods
        async void MoveMapToCurrentPosition()
        {
            await geolocatorService.GetLocation();
            if (geolocatorService.Latitude != 0 ||
                geolocatorService.Longitude != 0)
            {
                var position = new Position(
                    geolocatorService.Latitude,
                    geolocatorService.Longitude);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    position,
                    Distance.FromKilometers(.5)));
            }

            await LoadPins();
        }

        async Task LoadPins()
        {
            var ubicationsViewModel = UbicationsViewModel.GetInstance();
            await ubicationsViewModel.LoadPins();
            foreach (var pin in ubicationsViewModel.Pins)
            {
                MyMap.Pins.Add(pin);
            }
        }
        #endregion
    }

}
