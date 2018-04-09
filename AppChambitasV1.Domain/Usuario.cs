using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChambitasV1.Domain
{
    public class Usuario
    {
        [Key]
        public int Usua_ID { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string Usua_Nombre { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} should have {1} char lenght")]
        [DataType(DataType.EmailAddress)]
        public string Usua_Correo { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field {0} is required")]
        public string Usua_Contrasenia { get; set; }
        [Display(Name = "Is Active?")]
        public bool Usua_Activo { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Usua_FechaHora { get; set; }
        public int Usua_ModificadoPor { get; set; }

        [JsonIgnore]
        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
