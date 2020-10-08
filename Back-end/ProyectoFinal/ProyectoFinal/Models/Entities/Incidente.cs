using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models.Entities
{
    public class Incidente:Entidad
    {
        public int IncidenteId { get; set; }
        public int UsuarioReporteId { get; set; }
        public int UsuarioAsignadoId { get; set; }
        public int PrioridadId { get; set; }
        public int DepartamentoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Cierre { get; set; }
        public string ComentarioCierre { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }

        // Navigation properties
        public virtual UsuarioId Usuario { get; set; }
        public virtual UsuarioId Usuario1 { get; set; }
        public virtual UsuarioId Usuario2 { get; set; }
        public virtual UsuarioId Usuario3 { get; set; }

        public virtual Prioridad Prioridad { get; set; }
        public virtual Departamento Departamento { get; set; }

        // Navigation property
        public virtual ICollection<HistorialIncidente> HistorialIncidentes { get; set; }

    }
}
