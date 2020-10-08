using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Repositorios;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private IRepositorio<Departamento> repositorio;
        public DepartamentoController()
        {
            repositorio = new RepositorioDeDepartamento();
        }
        [HttpGet]
        public IEnumerable<Departamento> Get()
        {
            var parametros1 = new ParametrosDeQuery<Departamento>(1, 200);
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
        public OperationResult Insert([FromBody] Departamento departamento)
        {
            var result = repositorio.Agregar(departamento);
            return result;
        }
        [HttpPost]
        public OperationResult Update([FromBody] Departamento departamento)
        {
            var result = repositorio.Actualizar(departamento);
            return result;
        }
    }
}