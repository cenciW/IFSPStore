using IFSPSTore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{

    /*  `id` INT NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(100) NULL,
  `Endereco` VARCHAR(100) NULL,
  `Documento` VARCHAR(45) NULL,
  `Bairro` VARCHAR(45) NULL,
  `Cidade` VARCHAR(45) NULL,
  `idCidade` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_Cliente_Cidade`
    FOREIGN KEY (`idCidade`)
    REFERENCES `IFSPStoreDB`.`Cidade` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)*/


    public class Cliente : BaseEntity<int>
    {

        public string? Nome { get; set; }
        public string? Endereco{ get; set; }
        public string? Documento{ get; set; }
        public string? Bairro{ get; set; }
        public Cidade?  Cidade { get; set; }

        public Cliente(string nome, string endereco, string documento, string bairro, Cidade cidade)
        {
            Nome = nome;
            Endereco = endereco;
            Documento = documento;
            Bairro = bairro;
            Cidade  = cidade;
            
        }

        public Cliente()
        {

        }
    }
}
