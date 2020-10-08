﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models.Entities
{
    public class Sla:Entidad
    {
        public int SlaId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadHoras { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }

        // Navigation properties
        public virtual UsuarioId Usuario { get; set; }
        public virtual UsuarioId Usuario1 { get; set; }


        // Navigation property
        public virtual ICollection<Prioridad> Prioridades { get; set; }
    }
}
