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

namespace ProyectoFinal.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IRepositorio<UsuarioId> repositorio;
        public UsuariosController()
        {
            repositorio = new RepositorioDeUsuarios();
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
        [HttpGet("eliminar")]

        public OperationResult Delete(int id)
        {
            var result = repositorio.Eliminar(id);
            return result;
        }
        [HttpPost("registrar")]
        public OperationResult Insert([FromBody] UsuarioId usuario)
        {
            var result = repositorio.Agregar(usuario);
            return result;
        }
        [HttpPost("actualizar")]
        public OperationResult Update([FromBody] UsuarioId usuario)
        {
            var result = repositorio.Actualizar(usuario);
            return result;
        }
    }
}