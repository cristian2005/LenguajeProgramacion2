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
    [Route("api/puestos")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private IRepositorio<Puesto> repositorio;
        private RepositorioDeDepartamento repositorio_departamento;

        public PuestosController()
        {
            repositorio = new RepositorioDePuesto();
            repositorio_departamento = new RepositorioDeDepartamento();
        }
        [HttpGet("getpuestos")]
        public dynamic Get()
        {
            var parametros1 = new ParametrosDeQuery<Puesto>(1, 200);
            parametros1.OrderBy = x => x.Id;
            parametros1.Where = x => x.Borrado == false;

            var result = repositorio.EncontrarPor(parametros1).ToList();

            var departamentos = new List<Departamento>();
            departamentos = repositorio_departamento.GetDepartamentos();
               
            return result;
        }
        [HttpGet]
        public OperationResult Delete(int id)
        {
            var result = repositorio.Eliminar(id);
            return result;
        }
        [HttpPost("insertarpuestos")]
        public OperationResult Insert([FromBody] Puesto puesto)
        {
            puesto.FechaRegistro = DateTime.Now;
            puesto.FechaModificacion = DateTime.Now;

            var result = repositorio.Agregar(puesto);
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