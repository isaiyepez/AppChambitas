using System;
using System.Windows.Input;
using AppChambitasV1.Services;
using AppChambitasV1.ViewModels;
using GalaSoft.MvvmLight.Command;

namespace AppChambitasV1.Models
{
    public class TiposServiciosDetalle
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region Properties
        public int TipoServDeta_ID { get; set; }

        public int TipoServ_ID { get; set; }

        public string TipoServDeta_Nombre { get; set; }

        public string TipoServDeta_Descripcion { get; set; }

        public decimal TipoServDeta_Precio { get; set; }
        #endregion

        #region Constructors
        public TiposServiciosDetalle()
        {            
            navigationService = new NavigationService();
        }
        #endregion

        #region Commands
        public ICommand SelectTecnicoCommand
        {
            get
            {
                return new RelayCommand(SelectTecnico);
            }
        }

        async void SelectTecnico()
        {
            MainViewModel.GetInstance().Tecnicos =
                             new TecnicosViewModel();
            await navigationService.NavigateOnMaster("TecnicosView");
        }

        #endregion
    }
}
