using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class ApplicationDbContext:DbContext
    {
        private  string myDb1ConnectionString = @"Data Source=DAVID\SQLEXPRESS2014;Initial Catalog=ADONET;User ID=sa;Password=COSEFI@1234;";

        //Entities
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Sla> Slas { get; set; }
        public DbSet<UsuarioId> Usuarios { get; set; }
        public DbSet<HistorialIncidente> HistorialIncidentes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(myDb1ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Asignando primary key a tablas
            modelBuilder.Entity<Departamento>().HasKey(x => x.DepartamentoId);
            modelBuilder.Entity<Incidente>().HasKey(x => x.IncidenteId);
            modelBuilder.Entity<Prioridad>().HasKey(x => x.PrioridadId);
            modelBuilder.Entity<Puesto>().HasKey(x => x.PuestoId);
            modelBuilder.Entity<Sla>().HasKey(x => x.SlaId);
            modelBuilder.Entity<UsuarioId>().HasKey(x => x.Usuarioid);
            modelBuilder.Entity<HistorialIncidente>().HasKey(x => x.HistorialIncidenteId);

            //Longitud o tamano a los varchar
            modelBuilder.Entity<Departamento>().Property(x => x.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Departamento>().Property(x => x.Estatus).HasMaxLength(2);

            modelBuilder.Entity<UsuarioId>().Property(x => x.Nombre).HasMaxLength(100);
            modelBuilder.Entity<UsuarioId>().Property(x => x.Apellido).HasMaxLength(100);
            modelBuilder.Entity<UsuarioId>().Property(x => x.Cedula).HasMaxLength(11);
            modelBuilder.Entity<UsuarioId>().Property(x => x.Correo).HasMaxLength(50);
            modelBuilder.Entity<UsuarioId>().Property(x => x.Telefono).HasMaxLength(15);
            modelBuilder.Entity<UsuarioId>().Property(x => x.NombreUsuario).HasMaxLength(100);
            modelBuilder.Entity<UsuarioId>().Property(x => x.Contrasena).HasMaxLength(500);
            modelBuilder.Entity<UsuarioId>().Property(x => x.Estatus).HasMaxLength(2);

            modelBuilder.Entity<Sla>().Property(x => x.Descripcion).HasMaxLength(200);
            modelBuilder.Entity<Sla>().Property(x => x.Estatus).HasMaxLength(2);

            modelBuilder.Entity<Puesto>().Property(x => x.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Puesto>().Property(x => x.Estatus).HasMaxLength(2);

            modelBuilder.Entity<Prioridad>().Property(x => x.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Prioridad>().Property(x => x.Estatus).HasMaxLength(2);

            modelBuilder.Entity<Incidente>().Property(x => x.Titulo).HasMaxLength(200);
            modelBuilder.Entity<Incidente>().Property(x => x.Descripcion).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Incidente>().Property(x => x.ComentarioCierre).HasMaxLength(500);
            modelBuilder.Entity<Incidente>().Property(x => x.Estatus).HasMaxLength(2);

            modelBuilder.Entity<HistorialIncidente>().Property(x => x.Comentario).HasMaxLength(500);
            modelBuilder.Entity<HistorialIncidente>().Property(x => x.Estatus).HasMaxLength(2);


            //Agregando foregin key
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Departamentos)
                .WithOne(e => e.Usuario).HasForeignKey(x => x.CreadoPor).IsRequired(false);
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Departamento1)
               .WithOne(e => e.Usuario1).HasForeignKey(x => x.ModificadoPor).OnDelete(DeleteBehavior.NoAction).IsRequired(false);


            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Puestos)
              .WithOne(e => e.Usuario).HasForeignKey(x => x.CreadoPor);
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Puesto1)
               .WithOne(e => e.Usuario1).HasForeignKey(x => x.ModificadoPor).OnDelete(DeleteBehavior.NoAction).IsRequired(false);

            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Slas)
              .WithOne(e => e.Usuario).HasForeignKey(x => x.CreadoPor);
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Slas1)
               .WithOne(e => e.Usuario1).HasForeignKey(x => x.ModificadoPor).OnDelete(DeleteBehavior.NoAction).IsRequired(false);

            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Prioridades)
              .WithOne(e => e.Usuario).HasForeignKey(x => x.CreadoPor);
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Prioridades1)
               .WithOne(e => e.Usuario1).HasForeignKey(x => x.ModificadoPor).OnDelete(DeleteBehavior.NoAction).IsRequired(false);

            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Incidentes)
              .WithOne(e => e.Usuario).HasForeignKey(x => x.CreadoPor).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Incidentes1)
               .WithOne(e => e.Usuario1).HasForeignKey(x => x.ModificadoPor).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Incidentes2)
               .WithOne(e => e.Usuario2).HasForeignKey(x => x.UsuarioAsignadoId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.Incidentes3)
               .WithOne(e => e.Usuario3).HasForeignKey(x => x.UsuarioReporteId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UsuarioId>().HasMany(x => x.HistorialIncidentes)
              .WithOne(e => e.Usuario).HasForeignKey(x => x.CreadoPor);
            modelBuilder.Entity<UsuarioId>().HasMany(x => x.HistorialIncidentes1)
               .WithOne(e => e.Usuario1).HasForeignKey(x => x.ModificadoPor).OnDelete(DeleteBehavior.NoAction).IsRequired(false);

            modelBuilder.Entity<Departamento>().HasMany(x => x.Puestos)
               .WithOne(e => e.Departamento).HasForeignKey(x => x.DepartamentoId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            modelBuilder.Entity<Departamento>().HasMany(x => x.Incidentes)
              .WithOne(e => e.Departamento).HasForeignKey(x => x.DepartamentoId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Puesto>().HasMany(x => x.Usuarios)
            .WithOne(e => e.Puesto).HasForeignKey(x => x.PuestoId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sla>().HasMany(x => x.Prioridades)
            .WithOne(e => e.Sla).HasForeignKey(x => x.SlaId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prioridad>().HasMany(x => x.Incidentes)
            .WithOne(e => e.Prioridad).HasForeignKey(x => x.PrioridadId).OnDelete(DeleteBehavior.NoAction);
          
        }
    }
}
