using ProyectoFinal.Contractos;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorios
{
    public class RepositorioDeIncidentes : CRUD<Incidente>, IRepositorioIncidentes
    {
        void IRepositorioIncidentes.AccionesPersonalizadas(Incidente incidente)
        {
            throw new NotImplementedException();
        }
    }
}
