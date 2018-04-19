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
        //Cada que se utilice la clase datacontext, se conecta
        //a la base de datos
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Tecnico> Tecnicoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ServiciosTecnicos> ServiciosTecnicos { get; set; }

        public DbSet<TiposServicios> TiposServicios { get; set; }

        public DbSet<TiposServiciosDetalle> TiposServiciosDetalles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Ubication> Ubications { get; set; }
    }
}
