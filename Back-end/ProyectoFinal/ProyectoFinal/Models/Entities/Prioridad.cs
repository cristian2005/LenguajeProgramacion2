﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models.Entities
{
    public class Prioridad:Entidad
    {
        public int PrioridadId { get; set; }
        public int SlaId { get; set; }
        public string Nombre { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public int ModificadoPor { get; set; }

        // Navigation properties
        public virtual UsuarioId Usuario { get; set; }
        public virtual UsuarioId Usuario1 { get; set; }

        public virtual Sla Sla { get; set; }


        // Navigation property
        public virtual ICollection<Incidente> Incidentes { get; set; }
    }
}
