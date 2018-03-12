using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChambitasV1.Domain
{
    public class TiposServiciosDetalle
    {
        [Key]
        public int TipoServDeta_ID { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public int TipoServ_ID { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string TipoServDeta_Nombre { get; set; }
        public string TipoServDeta_Descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode =false)]
        public decimal TipoServDeta_Precio { get; set; }

        [JsonIgnore]
        public virtual TiposServicios TiposServicios { get; set; }

    }
}
