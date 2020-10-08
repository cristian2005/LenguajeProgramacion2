using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorios
{
   
        public interface IRepositorio<T>
        {
            OperationResult Agregar(T entidad);
        OperationResult Eliminar(int id);
        OperationResult Actualizar(T entidad);
            int Contar(Expression<Func<T, bool>> where);
            T ObtenerPorId(int id);
            IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery);
        }
}
