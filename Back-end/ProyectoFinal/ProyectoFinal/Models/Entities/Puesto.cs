using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models.Entities
{
    public class Puesto
    {
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public int ModificadoPor { get; set; }
    }
}
