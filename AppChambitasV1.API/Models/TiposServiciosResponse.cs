using AppChambitasV1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppChambitasV1.API.Models
{
    public class TiposServiciosResponse
    {
        
        public int TipoServ_ID { get; set; }
       
        public string TipoServ_Nombre { get; set; }
       
        public string TipoServ_Descripcion { get; set; }

       
        public List<TiposServiciosDetalleResponse> TiposServiciosDetalles { get; set; }
    }
}