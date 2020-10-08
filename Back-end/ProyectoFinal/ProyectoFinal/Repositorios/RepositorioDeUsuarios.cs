using ProyectoFinal.Contractos;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorios
{
    public class RepositorioDeUsuarios : CRUD<UsuarioId>, IRepositorioUsuarios
    {
        public void AccionesPersonalizadas(UsuarioId usuario)
        {
            throw new NotImplementedException();
        }
    }
}
