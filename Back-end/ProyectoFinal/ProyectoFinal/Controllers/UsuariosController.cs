using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Repositorios;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ProyectoFinal.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IRepositorio<UsuarioId> repositorio;
        private RepositorioDePuesto puesto_repo;

        public UsuariosController()
        {
            repositorio = new RepositorioDeUsuarios();
            puesto_repo = new RepositorioDePuesto();
        }
        [HttpPost("login")]
        public int login([FromBody] UsuarioId usuario)
        {
            var parametros1 = new ParametrosDeQuery<UsuarioId>(1, 1);
            parametros1.OrderBy = x => x.Id;
            parametros1.Where = x => x.Borrado == false && x.Correo==usuario.Correo && x.Contrasena==usuario.Contrasena;

            var result = repositorio.EncontrarPor(parametros1);

            return (result.ToList().Count==1)?result.FirstOrDefault().Id:0;

        }
        [HttpGet("obtener")]
        public dynamic Get()
        {
            var parametros1 = new ParametrosDeQuery<UsuarioId>(1, 200);
            parametros1.OrderBy = x => x.Id;
            parametros1.Where = x => x.Borrado == false;

            var result = repositorio.EncontrarPor(parametros1);

            var puestos = new List<Puesto>();
            puestos = puesto_repo.GetPuesto();

            return new { Usuario= result, Puesto= puestos };
        }
        [HttpPost("eliminar")]
        
        public OperationResult Delete([FromBody] UsuarioId usuario)
        {
            var usuario_old = repositorio.ObtenerPorId(usuario.Id);
            usuario_old.Borrado = true;

            var result = repositorio.Actualizar(usuario_old);
            return result;
        }
        [HttpPost("insertar")]
        public OperationResult Insert([FromBody] JsonElement body)
        {
            /*usuario.FechaRegistro = DateTime.Now;
            usuario.FechaModificacion = DateTime.Now;

            var result = repositorio.Agregar(usuario);
            return result;*/
            string json = System.Text.Json.JsonSerializer.Serialize(body);
            var myJsonObject = JsonConvert.DeserializeObject<UsuarioId>(json);
            myJsonObject.FechaRegistro = DateTime.Now;
            myJsonObject.FechaModificacion = DateTime.Now;

            var result = repositorio.Agregar(myJsonObject);
            return result;
        }
        [HttpPost("actualizar")]
        public OperationResult Update([FromBody] UsuarioId usuario)
        {
            var usuario_old = repositorio.ObtenerPorId(usuario.Id);

            usuario_old.FechaModificacion = DateTime.Now;
            usuario_old.ModificadoPor = usuario.ModificadoPor;
            usuario_old.Estatus = usuario.Estatus;
            usuario_old.Nombre = usuario.Nombre;
            usuario_old.Apellido = usuario.Apellido;
            usuario_old.Cedula = usuario.Cedula;
            usuario_old.Fecha_Nacimiento = usuario.Fecha_Nacimiento;
            usuario_old.Contrasena = usuario.Contrasena;
            usuario_old.Correo = usuario.Correo;
            usuario_old.Telefono = usuario.Telefono;
            usuario_old.NombreUsuario = usuario.NombreUsuario;


            var result = repositorio.Actualizar(usuario_old);
            return result;
        }
    }
}