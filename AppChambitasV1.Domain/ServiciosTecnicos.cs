using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AppChambitasV1.Domain
{
    public class ServiciosTecnicos
    {
        [Key]
        [Display(Name = "ServiciosTecnicos_ID")]
        public int ServTecn_ID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tecnico> Tecnico { get; set; }

        [JsonIgnore]
        public virtual ICollection<TiposServiciosDetalle> TiposServiciosDetalle { get; set; }

        [Display(Name = "Activo")]
        public bool ServTecn_Activo { get; set; }
    }
}
