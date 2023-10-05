using IFSPStore.Domain.Entities;
using IFSPSTore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
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

        #region Test Produto
         [TestMethod]
         public void TestProduto()
         {
             using (var context = new MyDbContext())
             {
                Grupo g = context.Grupo.First(g=>g.id == 1);
                

                 var produto = new Produto("Feijao", 15, 2, DateTime.UtcNow.ToLocalTime(), "BRI", g);

                 context.Produto.Add(produto);
                 context.SaveChanges();
             };
         }

         [TestMethod]
         public void TesteSelectProduto()
         {
             using (var context = new MyDbContext())
             {
                 foreach (var produto in context.Produto)
                 {
                     {
                        Console.WriteLine(JsonSerializer.Serialize(produto));
                     }
                 }
             }
         }
        #endregion

        #region Test Cliente
        [TestMethod]
        public void TestCliente()
        {
            using (var context = new MyDbContext())
            {
                Cidade c = context.Cidade.First(c => c.id == 1);


                var cliente = new Cliente("Cliente", "endereco", "rg do junin", "quebrada", c);

                context.Cliente.Add(cliente);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public void TestSelectCliente()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cliente in context.Cliente)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(cliente));
                    }
                }
            }
        }
        #endregion

        #region Test Venda
        [TestMethod]
        public void TestVenda()
        {
            using (var context = new MyDbContext())
            {
                Usuario u = context.Usuario.First(c => c.id == 1);
                Cliente c = context.Cliente.First(c => c.id == 1);
                Produto p = context.Produto.First(c => c.id == 1);

                List<VendaItem> vendaItens = new List<VendaItem>();
                
                var vendaItem = new VendaItem(1, 10, 100, p);
                vendaItens.Add(vendaItem);
                var venda = new Venda(DateTime.UtcNow.ToLocalTime(), 100, u, c, vendaItens);

                context.VendaItem.Add(vendaItem);
                context.Venda.Add(venda);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public void TestSelectVenda()
        {
            using (var context = new MyDbContext())
            {
                foreach (var vendas in context.Venda)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(vendas));
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
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<VendaItem> VendaItem { get; set; }
        public DbSet<Venda> Venda{ get; set; }
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

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto"); // Nome da tabela no banco de dados
                entity.HasKey(p => p.id); // Chave primária

                // Definindo as propriedades da tabela Produto
                entity.Property(e => e.Nome).HasMaxLength(100);
                entity.Property(e => e.Preco).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Quantidade);
                entity.Property(e => e.DataCompra);
                entity.Property(e => e.UnidadeVenda).HasMaxLength(10);

                // Relacionamento com a tabela Grupo (chave estrangeira)
                entity.HasOne(e => e.Grupo)
                    .WithMany() // Nenhum método WithMany() aqui indica um relacionamento de um para muitos
                    .HasForeignKey(e => e.Grupoid)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }*/

    }
}