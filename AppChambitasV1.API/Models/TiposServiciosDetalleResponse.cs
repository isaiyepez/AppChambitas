using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppChambitasV1.API.Models
{
    public class TiposServiciosDetalleResponse
    {
        public int TipoServDeta_ID { get; set; }
        
        public int TipoServ_ID { get; set; }
        
        public string TipoServDeta_Nombre { get; set; }
        public string TipoServDeta_Descripcion { get; set; }
        
        public decimal TipoServDeta_Precio { get; set; }                
    }
}