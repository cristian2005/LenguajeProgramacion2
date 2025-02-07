﻿using System;
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
               
            return new {Puestos= result, Departamentos=departamentos };
        }
        [HttpPost("eliminar")]
        public OperationResult Delete([FromBody] Puesto puesto)
        {
            var puesto_old = repositorio.ObtenerPorId(puesto.Id);
            puesto_old.Borrado = true;

            var result = repositorio.Actualizar(puesto_old);
            return result;
        }
        [HttpPost("insertar")]
        public OperationResult Insert([FromBody] Puesto puesto)
        {
            puesto.FechaRegistro = DateTime.Now;
            puesto.FechaModificacion = DateTime.Now;

            var result = repositorio.Agregar(puesto);
            return result;
        }
        [HttpPost("actualizar")]
        public OperationResult Update([FromBody] Puesto puesto)
        {
            var puesto_old = repositorio.ObtenerPorId(puesto.Id);

            puesto_old.FechaModificacion = DateTime.Now;
            puesto_old.ModificadoPor = puesto.ModificadoPor;
            puesto_old.Estatus = puesto.Estatus;
            puesto_old.Nombre = puesto.Nombre;
            puesto_old.DepartamentoId = puesto.DepartamentoId;


            var result = repositorio.Actualizar(puesto_old);
            return result;
        }
    }
}