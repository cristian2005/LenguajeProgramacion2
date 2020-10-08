using ProyectoFinal.Models.Entities;
using ProyectoFinal.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Contractos
{
    public interface IRepositorioUsuarios : IRepositorio<UsuarioId>
    {
        void AccionesPersonalizadas(UsuarioId usuario);
    }
}
