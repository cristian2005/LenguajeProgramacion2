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
    [Route("api/incidentes")]
    [ApiController]
    public class IncidentesController : ControllerBase
    {
        private IRepositorio<Incidente> repositorio;
        private RepositorioDeUsuarios usuarios_respo;
        private RepositorioDePrioridad prioridad_respo;
        private RepositorioDeDepartamento departamento_respo;


        public IncidentesController()
        {
            repositorio = new RepositorioDeIncidentes();
            usuarios_respo = new RepositorioDeUsuarios();
            prioridad_respo = new RepositorioDePrioridad();
            departamento_respo = new RepositorioDeDepartamento();
        }
        [HttpGet("getincidentes")]
        public dynamic Get()
        {
            var parametros1 = new ParametrosDeQuery<Incidente>(1, 200);
            parametros1.OrderBy = x => x.Id;
            parametros1.Where = x => x.Borrado == false;

            var result = repositorio.EncontrarPor(parametros1);
            var usuarios = new List<UsuarioId>();
            var departamentos = new List<Departamento>();
            var prioridads = new List<Prioridad>();


            usuarios = usuarios_respo.GetUsuarios();
            departamentos = departamento_respo.GetDepartamentos();
            prioridads = prioridad_respo.GetPrioridad();

            return new {Incidentes=result, Prioridades = prioridads, Usuarios = usuarios, 
                departamentos = departamentos };
        }
        [HttpPost("eliminar")]

        public OperationResult Delete([FromBody] Incidente data)
        {
            var data_old = repositorio.ObtenerPorId(data.Id);
            data_old.Borrado = true;

            var result = repositorio.Actualizar(data_old);
            return result;
        }
        [HttpPost("insertar")]

        public OperationResult Insert([FromBody] Incidente data)
        {
            data.FechaRegistro = DateTime.Now;
            data.FechaModificacion = DateTime.Now;

            var result = repositorio.Agregar(data);
            return result;
        }
        [HttpPost("actualizar")]

        public OperationResult Update([FromBody] Incidente data)
        {

            var puesto_old = repositorio.ObtenerPorId(data.Id);

            puesto_old.FechaModificacion = DateTime.Now;
            puesto_old.ModificadoPor = data.ModificadoPor;
            puesto_old.Estatus = data.Estatus;
            puesto_old.UsuarioAsignadoId = data.UsuarioAsignadoId;
            puesto_old.UsuarioReporteId = data.UsuarioReporteId;
            puesto_old.PrioridadId = data.PrioridadId;
            puesto_old.DepartamentoId = data.DepartamentoId;
            puesto_old.Titulo = data.Titulo;
            puesto_old.Descripcion = data.Descripcion;
            puesto_old.Fecha_Cierre = data.Fecha_Cierre;
            puesto_old.ComentarioCierre = data.ComentarioCierre;


            var result = repositorio.Actualizar(puesto_old);
            return result;
        }
    }
}