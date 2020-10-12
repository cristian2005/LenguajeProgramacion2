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
    [Route("api/departamento")]
    public class DepartamentoController : ControllerBase
    {
        private IRepositorio<Departamento> repositorio;
        public DepartamentoController()
        {
            repositorio = new RepositorioDeDepartamento();
        }
        [HttpGet("getdepartamento")]
        public IEnumerable<Departamento> Get()
        {
            var parametros1 = new ParametrosDeQuery<Departamento>(1, 200);
            parametros1.OrderBy = x => x.Id;
            parametros1.Where = x => x.Borrado == false;

            var result = repositorio.EncontrarPor(parametros1);
           return result;
        }
        [HttpPost("eliminardepartamento")]
        public OperationResult Eliminar([FromBody] Departamento departamento)
        {
            var departamento_old = repositorio.ObtenerPorId(departamento.Id);
            departamento_old.Borrado = true;

            var result = repositorio.Actualizar(departamento_old);
            return result;
        }
        [HttpPost("insertardepartamento")]
        public OperationResult Insert([FromBody] Departamento departamento)
        {
            departamento.FechaRegistro = DateTime.Now;
            departamento.FechaModificacion = DateTime.Now;

            var result = repositorio.Agregar(departamento);
            return result;
        }
        [HttpPost("actualizardepartamento")]
        public OperationResult Update([FromBody] Departamento departamento)
        {
            var departamento_old = repositorio.ObtenerPorId(departamento.Id);

            departamento_old.FechaModificacion = DateTime.Now;
            departamento_old.ModificadoPor = departamento.ModificadoPor;
            departamento_old.Estatus = departamento.Estatus;
            departamento_old.Nombre = departamento.Nombre;

            var result = repositorio.Actualizar(departamento_old);
            return result;
        }
    }
}