using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models.Entities
{
    public class UsuarioId
    {
        public int Usuarioid { get; set; }
        public int PuestoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public int ModificadoPor { get; set; }
    }
}
