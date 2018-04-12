using System;
using System.Collections.Generic;

namespace AppChambitasV1.Models
{
    public class TiposServicios
    {
        public int TipoServ_ID { get; set; }

        public string TipoServ_Nombre { get; set; }

        public string TipoServ_Descripcion { get; set; }

        public List<TiposServiciosDetalle> TiposServiciosDetalles { get; set; }
    }
}
