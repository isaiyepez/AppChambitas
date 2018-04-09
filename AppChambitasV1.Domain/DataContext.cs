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
    }
}
