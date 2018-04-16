using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppChambitasV1.Domain;

namespace AppChambitasV1.Backend.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<AppChambitasV1.Domain.Customer> Customers { get; set; }
    }
}