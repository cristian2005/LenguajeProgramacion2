using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoFinal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class ApplicationDbContext:DbContext
    {
        private  IConfiguration _configuration;
        private  string myDb1ConnectionString = null;

        //Entities
        public DbSet<Departamento> Departamentos { get; set; }
        public ApplicationDbContext()
        {
            myDb1ConnectionString = _configuration.GetConnectionString("myDb1");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(myDb1ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
