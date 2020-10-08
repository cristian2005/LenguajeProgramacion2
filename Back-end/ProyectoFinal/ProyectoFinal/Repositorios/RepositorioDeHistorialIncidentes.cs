using ProyectoFinal.Contractos;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorios
{
    public class RepositorioDeHistorialIncidentes : CRUD<HistorialIncidente>, IRepositorioHistorialIncidente
    {
        public void AccionesPersonalizadas(HistorialIncidente historialIncidente)
        {
            throw new NotImplementedException();
        }
    }
}
