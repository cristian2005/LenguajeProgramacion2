using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models.Entities
{
    public class UsuarioId:Entidad
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
        public int? CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }

        // Navigation properties
        public virtual Puesto Puesto { get; set; }

        // Navigation property
        public virtual ICollection<Departamento> Departamentos { get;  set; }
        public virtual ICollection<Departamento> Departamento1 { get; set; }

        public virtual ICollection<Puesto> Puestos { get; set; }
        public virtual ICollection<Puesto> Puesto1 { get; set; }

        public virtual ICollection<Sla> Slas { get; set; }
        public virtual ICollection<Sla> Slas1 { get; set; }

        public virtual ICollection<Prioridad> Prioridades { get; set; }
        public virtual ICollection<Prioridad> Prioridades1 { get; set; }

        public virtual ICollection<Incidente> Incidentes { get; set; }
        public virtual ICollection<Incidente> Incidentes1 { get; set; }
        public virtual ICollection<Incidente> Incidentes2 { get; set; }
        public virtual ICollection<Incidente> Incidentes3 { get; set; }

        public virtual ICollection<HistorialIncidente> HistorialIncidentes { get; set; }
        public virtual ICollection<HistorialIncidente> HistorialIncidentes1 { get; set; }



    }
}
