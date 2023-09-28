using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IFSPSTore.Domain.Entities;

namespace IFSPStore.Domain.Entities
{
    public class Usuario : BaseEntity<int>
    {
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        //[Timestamp]
        public DateTime? DataCadastro { get; set; }
        //[Timestamp] < ao inves do DateTime byte[]
        public DateTime? DataLogin { get; set; }
        public bool? Ativo { get; set; }

        
        public Usuario(string nome, string senha, string login, string email, DateTime datacadastro, DateTime datalogin, bool ativo)
        {
            Nome = nome;
            Senha = senha;
            Login = login;
            Email = email;
            DataCadastro= datacadastro;
            DataLogin= datalogin;
            Ativo = ativo;
        }

        public Usuario()
        {

        }
    }
}
