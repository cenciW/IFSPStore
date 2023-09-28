using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{
    public class Grupo : BaseEntity<int>
    {
        public string? Nome { get; set; }

        public Grupo(string nome)
        {
            Nome = nome;
        }

        public Grupo()
        {

        }
    }
}
