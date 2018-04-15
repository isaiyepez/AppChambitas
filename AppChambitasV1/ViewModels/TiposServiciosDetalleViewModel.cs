using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using AppChambitasV1.Models;

namespace AppChambitasV1.ViewModels
{
    public class TiposServiciosDetalleViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        List<TiposServiciosDetalle> tiposServiciosDetalles;
        ObservableCollection<TiposServiciosDetalle> _tiposServiciosDetalle;
        #endregion

        #region Properties
        public ObservableCollection<TiposServiciosDetalle> TiposServiciosDetalles
        {
            get
            {
                return _tiposServiciosDetalle;
            }
            set
            {
                if (_tiposServiciosDetalle != value)
                {
                    _tiposServiciosDetalle = value;
                    PropertyChanged?.Invoke(
                    this,
                        new PropertyChangedEventArgs(nameof(TiposServiciosDetalle)));
                }
            }
        }
        #endregion

        #region Constructor
        public TiposServiciosDetalleViewModel(List<TiposServiciosDetalle> tiposServiciosDetalles)
        {
            this.tiposServiciosDetalles = tiposServiciosDetalles;
            TiposServiciosDetalles = new ObservableCollection<TiposServiciosDetalle>(
                tiposServiciosDetalles.OrderBy(ts => ts.TipoServDeta_Nombre));
        }
        #endregion


    }
}
