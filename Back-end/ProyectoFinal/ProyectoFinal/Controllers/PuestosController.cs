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
    [Route("api/[puestos]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private IRepositorio<Puesto> repositorio;
        public PuestosController()
        {
            repositorio = new RepositorioDePuesto();
        }
        [HttpGet]
        public IEnumerable<Puesto> Get()
        {
            var parametros1 = new ParametrosDeQuery<Puesto>(1, 200);
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
        public OperationResult Insert([FromBody] Puesto usuario)
        {
            var result = repositorio.Agregar(usuario);
            return result;
        }
        [HttpPost]
        public OperationResult Update([FromBody] Puesto usuario)
        {
            var result = repositorio.Actualizar(usuario);
            return result;
        }
    }
}