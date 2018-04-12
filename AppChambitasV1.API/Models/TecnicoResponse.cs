using AppChambitasV1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppChambitasV1.API.Models
{
    public class TecnicoResponse
    {        
        public int Tecn_ID { get; set; }
        
        public string Tecn_Nombre { get; set; }
        
        public string Tecn_Correo { get; set; }
        
        public string Tecn_Contrasenia { get; set; }
      
        public string Tecn_Domicilio { get; set; }
        
        public int Tecn_Promedio { get; set; }
        
        public bool Tecn_Activo { get; set; }
        
        public string Tecn_Imagen { get; set; }
        
        public DateTime Tecn_FechaHora { get; set; }
        
        public int Tecn_ModificadoPor { get; set; }
       
        public List<Servicio> Servicios { get; set; }
    }
}