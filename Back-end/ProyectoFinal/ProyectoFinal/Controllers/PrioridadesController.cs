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
        private RepositorioDeSla sla_respo;
        
        public PrioridadesController()
        {
            repositorio = new RepositorioDePrioridad();
            sla_respo = new RepositorioDeSla();
        }
        [HttpGet("getprioridades")]
        public dynamic Get()
        {
            var parametros1 = new ParametrosDeQuery<Prioridad>(1, 200);
            parametros1.OrderBy = x => x.Id;
            parametros1.Where = x => x.Borrado == false;

            var result = repositorio.EncontrarPor(parametros1);


            var slas = new List<Sla>();
            slas = sla_respo.GetSla();

            return new { Prioridades = result, Sla = slas };
        }
        [HttpPost("eliminar")]
        public OperationResult Delete([FromBody] Prioridad data)
        {
            var prioridad_old = repositorio.ObtenerPorId(data.Id);
            prioridad_old.Borrado = true;

            var result = repositorio.Actualizar(prioridad_old);
            return result;
        }
        [HttpPost("insertar")]
        public OperationResult Insert([FromBody] Prioridad data)
        {
            data.FechaRegistro = DateTime.Now;
            data.FechaModificacion = DateTime.Now;

            var result = repositorio.Agregar(data);
            return result;
        }
        [HttpPost("actualizar")]

        public OperationResult Update([FromBody] Prioridad data)
        {
            var puesto_old = repositorio.ObtenerPorId(data.Id);

            puesto_old.FechaModificacion = DateTime.Now;
            puesto_old.ModificadoPor = data.ModificadoPor;
            puesto_old.Estatus = data.Estatus;
            puesto_old.Nombre = data.Nombre;
            puesto_old.SlaId = data.SlaId;


            var result = repositorio.Actualizar(puesto_old);
            return result;
        }
    }
}