using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Repositorios;

namespace ProyectoFinal.Controllers
{
    [Route("api/prioridades")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        private IRepositorio<Prioridad> repositorio;
        public PrioridadesController()
        {
            repositorio = new RepositorioDePrioridad();
        }
        [HttpGet]
        public IEnumerable<Prioridad> Get()
        {
            var parametros1 = new ParametrosDeQuery<Prioridad>(1, 200);
            parametros1.OrderBy = x => x.Id;
            parametros1.Where = x => x.Borrado == false;

            var result = repositorio.EncontrarPor(parametros1);
            return result;
        }
        [HttpGet]
        public OperationResult Delete(int id)
        {
            var result = repositorio.Eliminar(id);
            return result;
        }
        [HttpPost]
        public OperationResult Insert([FromBody] Prioridad data)
        {
            var result = repositorio.Agregar(data);
            return result;
        }
        [HttpPost]
        public OperationResult Update([FromBody] Prioridad data)
        {
            var result = repositorio.Actualizar(data);
            return result;
        }
    }
}