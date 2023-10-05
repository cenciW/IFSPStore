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
        #region Test Usuario
        [TestMethod]
        public void TestUsuario()
        {
            using (var context = new MyDbContext()){
                var usuario = new Usuario("Murilo Varges",
                            "murilo", "semsenha", "email",
                            DateTime.UtcNow.ToLocalTime(), DateTime.UtcNow.ToLocalTime(), true);

                context.Usuario.Add(usuario);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public void TestSelectUsuario()
        {
            using (var context = new MyDbContext())
            {
                foreach (var usuario in context.Usuario)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(usuario));
                    }
                }
            }
        }
        #endregion

        #region Teste Cidade
        [TestMethod]
        public void TestCidade()
        {
            using (var context = new MyDbContext())
            {
                var cidade = new Cidade("Aracatuba", "SP");

                context.Cidade.Add(cidade);
                context.SaveChanges();
            };
            
        }

        [TestMethod]
        public void TestSelectCidade()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cidade in context.Cidade)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(cidade));
                    }
                }
            };
        }
        #endregion

        #region Test Grupo
        [TestMethod]
        public void TestGrupo()
        {
            using (var context = new MyDbContext())
            {
                var grupo = new Grupo("Yakissoba");

                context.Grupo.Add(grupo);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public void TesteSelectGrupo()
        {
            using (var context = new MyDbContext())
            {
                foreach (var grupo in context.Grupo)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(grupo));
                    }
                }
            }
        }
        #endregion
    }

    public class MyDbContext : DbContext{
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cidade> Cidade{ get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Produto> Produto { get; set; }
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