using ProyectoFinal.Contractos;
using ProyectoFinal.Models;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorios
{
    public class RepositorioDeSla : CRUD<Sla>, IRepositorioSla
    {
        public void AccionesPersonalizadas(Sla sla)
        {
            throw new NotImplementedException();
        }
        public List<Sla> GetSla()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    var result = db.Slas.ToList();
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
