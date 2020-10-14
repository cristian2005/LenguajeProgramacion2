using ProyectoFinal.Contractos;
using ProyectoFinal.Models;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorios
{
    public class RepositorioDePrioridad : CRUD<Prioridad>, IRepositorioPrioridades
    {
        void IRepositorioPrioridades.AccionesPersonalizadas(Prioridad prioridad)
        {
            throw new NotImplementedException();
        }
        public List<Prioridad> GetPrioridad()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    var result = db.Prioridades.ToList();
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
