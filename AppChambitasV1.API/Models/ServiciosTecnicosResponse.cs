using AppChambitasV1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppChambitasV1.API.Models
{
    public class ServiciosTecnicosResponse
    {
        public int ServTecn_ID { get; set; }
        
        public List<Tecnico> Tecnicos { get; set; }

        public List<TiposServiciosDetalle> TiposServiciosDetalles { get; set; }

        public bool ServTecn_Activo { get; set; }
    }
}