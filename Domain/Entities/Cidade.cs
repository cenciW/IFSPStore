using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPSTore.Domain.Entities
{
    public class Cidade : BaseEntity<int>
    {

         // ? não anulável
        public string? Nome { get; set; }
        public string? Estado { get; set; }

        public Cidade(string nome, string estado)
        {
            Nome = nome;
            Estado = estado;
        }

        public Cidade()
        {

        }

    }
}
