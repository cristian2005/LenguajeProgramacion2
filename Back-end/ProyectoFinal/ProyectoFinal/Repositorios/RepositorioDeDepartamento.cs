using ProyectoFinal.Contractos;
using ProyectoFinal.Models;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorios
{
    public class RepositorioDeDepartamento : CRUD<Departamento>, IrepositorioDepartamento
    {
        public void AccionesPersonalizadas(Departamento departamento)
        {
            throw new NotImplementedException();
        }
        public List<Departamento> GetDepartamentos()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                  var  result= db.Departamentos.ToList();
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
