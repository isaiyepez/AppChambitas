using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppChambitasV1.Domain;

namespace AppChambitasV1.Backend.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<AppChambitasV1.Domain.Servicio> Servicios { get; set; }

        public System.Data.Entity.DbSet<AppChambitasV1.Domain.Tecnico> Tecnicoes { get; set; }

        public System.Data.Entity.DbSet<AppChambitasV1.Domain.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<AppChambitasV1.Domain.ServiciosTecnicos> ServiciosTecnicos { get; set; }

        public System.Data.Entity.DbSet<AppChambitasV1.Domain.TiposServicios> TiposServicios { get; set; }

        public System.Data.Entity.DbSet<AppChambitasV1.Domain.TiposServiciosDetalle> TiposServiciosDetalles { get; set; }
    }
}