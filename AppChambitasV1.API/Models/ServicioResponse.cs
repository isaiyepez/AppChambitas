using AppChambitasV1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppChambitasV1.API.Models
{
    public class ServicioResponse
    {
        
        public int Serv_ID { get; set; }
        
        public int Usua_ID { get; set; }
        
        public int Tecn_ID { get; set; }
        
        public DateTime Serv_FechaHoraSolicitud { get; set; }
        
        public DateTime Serv_FechaSolicitada { get; set; }
        public string Serv_Latitud { get; set; }
        public string Serv_Longitud { get; set; }
        
        public DateTime Serv_FechaHoraCumplida { get; set; }
        public decimal Serv_Evaluacion { get; set; }
        public string Serv_Domicilio { get; set; }
        
        public string Serv_Comentarios { get; set; }
        
        public DateTime Serv_FechaHora { get; set; }
        public int Serv_ModificadoPor { get; set; }        
    }
}