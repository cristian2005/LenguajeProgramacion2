using ProyectoFinal.Contractos;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorios
{
    public class RepositorioDePuesto : CRUD<Puesto>, IRepositorioPuestos
    {
        public void AccionesPersonalizadas(Puesto puesto)
        {
            throw new NotImplementedException();
        }
    }
}
