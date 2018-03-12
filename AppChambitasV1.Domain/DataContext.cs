using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChambitasV1.Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ChambitasBD")
        {
        }
        public DbSet<TiposServicios> TiposServicios { get; set; }

        public DbSet<TiposServiciosDetalle> TiposServiciosDetalles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tecnico> Tecnicoes { get; set; }

        public DbSet<Servicio> Servicios { get; set; }
    }
}
