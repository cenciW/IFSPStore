using IFSPStore.Domain.Entities;
using IFSPSTore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using static IFSPStore.Domain.Entities.Venda;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestRepository
    {
        [TestMethod]
        public void TestUsuario()
        {

        }
    }

    public class MyDbContext : DbContext{
        public DbSet<Usuario> Usuario { get; set; }
        public MyDbContext()
        {
            //Força a criação do banco de dados;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = "localhost";
            var port = "3306";
            var database = "IFSPStore";
            var username = "root";
            var password = "";
            var strCon = $"Server={server};Port={port};" + $"Database={database}; Uid={username};Pwd={password}";

            if (!optionsBuilder.IsConfigured) { 
                optionsBuilder.UseMySql(strCon, ServerVersion.AutoDetect(strCon));  
            }
        }
    }
}