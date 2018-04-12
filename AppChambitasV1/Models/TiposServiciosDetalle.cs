using System;
namespace AppChambitasV1.Models
{
    public class TiposServiciosDetalle
    {
        public int TipoServDeta_ID { get; set; }

        public int TipoServ_ID { get; set; }

        public string TipoServDeta_Nombre { get; set; }

        public string TipoServDeta_Descripcion { get; set; }

        public decimal TipoServDeta_Precio { get; set; }
    }
}
