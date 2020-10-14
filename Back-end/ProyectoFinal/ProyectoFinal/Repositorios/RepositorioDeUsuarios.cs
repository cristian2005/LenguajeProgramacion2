using ProyectoFinal.Contractos;
using ProyectoFinal.Models;
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
        public List<UsuarioId> GetUsuarios()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    var result = db.Usuarios.ToList();
                    return result;
                }
            }
            catch (Exception err)
            {
                return null;
            }

        }
    }
}
