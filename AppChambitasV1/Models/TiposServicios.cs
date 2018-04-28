using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using AppChambitasV1.Views;
using AppChambitasV1.ViewModels;
using AppChambitasV1.Services;

namespace AppChambitasV1.Models
{
    public class TiposServicios
    {
        #region Services
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Properties
        public int TipoServ_ID { get; set; }

        public string TipoServ_Nombre { get; set; }

        public string TipoServ_Descripcion { get; set; }

        public List<TiposServiciosDetalle> TiposServiciosDetalles { get; set; }
        #endregion

        #region Constructors
        public TiposServicios()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
        }
        #endregion
        #region Commands
        public ICommand SelectTiposServiciosCommand
        {
            get
            {
                return new RelayCommand(SelectTiposServicios);
            }
        }

        async void SelectTiposServicios()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.TiposServiciosDetalle = new TiposServiciosDetalleViewModel(TiposServiciosDetalles);
            mainViewModel.TiposServicios = this;
            await navigationService.NavigateOnMaster("TiposServiciosDetalleView");
            //mainViewModel.TiposServiciosDetalle = new TiposServiciosDetalleViewModel(TiposServiciosDetalles);
            //await Application.Current.MainPage.Navigation.PushAsync(
                //new TiposServiciosDetalleView());

        }
        #endregion
    }
}
