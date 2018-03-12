using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChambitasV1.Domain
{
    public class Servicio
    {
        [Key]
        public int Serv_ID { get; set; }
        [Required(ErrorMessage ="The field {0} is required")]
        public int Usua_ID { get; set; }
        [Required(ErrorMessage ="The field {0} is required")]
        public int Tecn_ID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Serv_FechaHoraSolicitud { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Serv_FechaSolicitada { get; set; }
        public string Serv_Latitud { get; set; }
        public string Serv_Longitud { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Serv_FechaHoraCumplida { get; set; }
        public decimal Serv_Evaluacion { get; set; }
        public string Serv_Domicilio { get; set; }
        [DataType(DataType.MultilineText)]
        public string Serv_Comentarios { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Serv_FechaHora { get; set; }
        public int Serv_ModificadoPor { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        [JsonIgnore]
        public virtual Tecnico Tecnico { get; set; }
    }
}
