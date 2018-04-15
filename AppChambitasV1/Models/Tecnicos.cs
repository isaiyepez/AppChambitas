using System;
namespace AppChambitasV1.Models
{
    public class Tecnicos
    {
        #region Properties
        public int Tecn_ID { get; set; }

        public string Tecn_Nombre { get; set; }

        public string Tecn_Correo { get; set; }

        public string Tecn_Contrasenia { get; set; }

        public string Tecn_Domicilio { get; set; }

        public int Tecn_Promedio { get; set; }

        public bool Tecn_Activo { get; set; }

        public string Tecn_Imagen { get; set; }

        public DateTime Tecn_FechaHora { get; set; }

        public int Tecn_ModificadoPor { get; set; }

        public string ImageFullPath
        {
            get
            {
                return string.Format(
                    "appchambitasv1backend2018.azurewebsites.net/{0}", 
                    Tecn_Imagen.Substring(1));
            }
        }

        #endregion
    }
}
