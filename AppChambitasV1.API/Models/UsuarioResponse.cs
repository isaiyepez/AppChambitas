using AppChambitasV1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppChambitasV1.API.Models
{
    public class UsuarioResponse
    {
        
        public int Usua_ID { get; set; }
        
        public string Usua_Nombre { get; set; }
        
        public string Usua_Correo { get; set; }
        
        public string Usua_Contrasenia { get; set; }
        
        public bool Usua_Activo { get; set; }
  
        public DateTime Usua_FechaHora { get; set; }
        public int Usua_ModificadoPor { get; set; }

        
        public List<Servicio> Servicios { get; set; }
    }
}