using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{
    /*
     CREATE TABLE IF NOT EXISTS `IFSPStoreDB`.`Produto` (
  `id` INT NOT NULL,
  `Nome` VARCHAR(100) NULL,
  `Preco` DECIMAL(10,2) NULL,
  `Quantidade` INT NULL,
  `DataCompra` DATE NULL,
  `UnidadeVenda` VARCHAR(10) NULL,
  `Produtocol` VARCHAR(45) NULL,
  `idGrupo` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_Produto_Grupo`
    FOREIGN KEY (`idGrupo`)
    REFERENCES `IFSPStoreDB`.`Grupo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;*/
    public class Produto : BaseEntity<int>
    {
        public Produto()
        {

        }

        public string? Nome { get; set; }
        public double? Preco{ get; set; }
        public int? Quantidade{ get; set; }
        public DateTime? DataCompra{ get; set; }
        public string? UnidadeVenda { get; set; }
        public Grupo? Grupo { get; set;}

        public Produto(string nome, double preco, int qtd, DateTime dtComp, string unidVend, Grupo grupo)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = qtd;
            DataCompra = dtComp;
            UnidadeVenda= unidVend;
            Grupo = grupo;

        }
    }
}
