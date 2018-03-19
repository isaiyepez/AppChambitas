using AppChambitasV1.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppChambitasV1.Backend.Models
{
    [NotMapped]
    public class TecnicoView : Tecnico
    {
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}