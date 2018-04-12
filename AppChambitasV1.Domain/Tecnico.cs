using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChambitasV1.Domain
{
    public class Tecnico
    {
        [Key]
        [Display(Name = "Técnico ID")]
        public int Tecn_ID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Nombre del técnico")]
        public string Tecn_Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo del técnico")]
        public string Tecn_Correo { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Tecn_Contrasenia { get; set; }

        [Display(Name = "Domicilio")]
        public string Tecn_Domicilio { get; set; }

        [Display(Name = "Promedio")]
        public int Tecn_Promedio { get; set; }

        [Display(Name = "Activo")]
        public bool Tecn_Activo { get; set; }

        [Display(Name = "Imagen")]
        public string Tecn_Imagen { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "FechaHora")]
        public DateTime Tecn_FechaHora { get; set; }

        [Display(Name = "ModificadoPor")]
        public int Tecn_ModificadoPor { get; set; }

        [JsonIgnore]
        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
