using System;
namespace AppChambitasV1.Models
{
    public class Usuario
    {
        public int Usua_ID { get; set; }
        public string Usua_Nombre { get; set; }
        public string Usua_Correo { get; set; }
        public string Usua_Contrasenia { get; set; }
        public DateTime Usua_FechaHora { get; set; }
        public int Usua_ModificadoPor { get; set; }

    }
}
