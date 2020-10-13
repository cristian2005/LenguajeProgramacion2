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
    [Route("api/sla")]
    [ApiController]
    public class SlaController : ControllerBase
    {
        private IRepositorio<Sla> repositorio;
        public SlaController()
        {
            repositorio = new RepositorioDeSla();
        }
        [HttpGet("getsla")]
        public IEnumerable<Sla> Get()
        {
            var parametros1 = new ParametrosDeQuery<Sla>(1, 200);
            parametros1.OrderBy = x => x.Id;
            parametros1.Where = x => x.Borrado == false;

            var result = repositorio.EncontrarPor(parametros1);
            return result;
        }
        [HttpPost]
        public OperationResult Delete([FromBody] Sla data)
        {
            var sla_old = repositorio.ObtenerPorId(data.Id);
            sla_old.Borrado = true;

            var result = repositorio.Actualizar(sla_old);
            return result;
        }
        [HttpPost("insertar")]

        public OperationResult Insert([FromBody] Sla data)
        {
            data.FechaRegistro = DateTime.Now;
            data.FechaModificacion = DateTime.Now;

            var result = repositorio.Agregar(data);
            return result;
        }
        [HttpPost("actualizar")]

        public OperationResult Update([FromBody] Sla data)
        {

            var puesto_old = repositorio.ObtenerPorId(data.Id);

            puesto_old.FechaModificacion = DateTime.Now;
            puesto_old.ModificadoPor = data.ModificadoPor;
            puesto_old.Estatus = data.Estatus;
            puesto_old.CantidadHoras = data.CantidadHoras;
            puesto_old.Descripcion = data.Descripcion;


            var result = repositorio.Actualizar(puesto_old);
            return result;
        }
    }
}