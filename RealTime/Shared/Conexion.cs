using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace RealTime.Shared
{
    public class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options) : base(options) { }
        public DbSet<Productos> Productos { get; set; }
        //public DbSet<Marcas> Marcas { get; set; }
    }

    public class Conectar
    {
        private const string conexion = "server=localhost; database=db_empresas; user=usr_empresa; password=Empres@123";
        public static Conexion GetConexion()
        {
            var builder = new DbContextOptionsBuilder<Conexion>();
            builder.UseMySQL(conexion);
            return new Conexion(builder.Options);
        }
    }
}
