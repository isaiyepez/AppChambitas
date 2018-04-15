using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using AppChambitasV1.Views;
using AppChambitasV1.ViewModels;


namespace AppChambitasV1.Models
{
    public class TiposServicios
    {
        #region Properties
        public int TipoServ_ID { get; set; }

        public string TipoServ_Nombre { get; set; }

        public string TipoServ_Descripcion { get; set; }

        public List<TiposServiciosDetalle> TiposServiciosDetalles { get; set; }
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
            await Application.Current.MainPage.Navigation.PushAsync(
                new TiposServiciosDetalleView());
        }
        #endregion
    }
}
