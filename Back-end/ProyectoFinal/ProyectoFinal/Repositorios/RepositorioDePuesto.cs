using ProyectoFinal.Contractos;
using ProyectoFinal.Models;
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
        public List<Puesto> GetPuesto()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    var result = db.Puestos.ToList();
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
