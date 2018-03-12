using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChambitasV1.Domain
{
    public class TiposServicios
    {
        [Key]
        [Display(Name = "ID Tipo Servicio")]
        public int TipoServ_ID { get; set; }
        [Required(ErrorMessage ="The field {0} is required")]
        [Display(Name = "Nombre del Tipo de Servico")]
        public string TipoServ_Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string TipoServ_Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<TiposServiciosDetalle> TiposServiciosDetalles { get; set; }
    }
}
