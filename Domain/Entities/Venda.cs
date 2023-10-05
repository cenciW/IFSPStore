using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{

    /*

CREATE TABLE IF NOT EXISTS `IFSPStoreDB`.`Venda` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Data` TIMESTAMP NULL,
  `ValorTotal` DECIMAL(10,2) NULL,
  `idUsuario` INT NOT NULL,
  `idCliente` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_Venda_Usuario`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `IFSPStoreDB`.`Usuario` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Venda_Cliente`
    FOREIGN KEY (`idCliente`)
    REFERENCES `IFSPStoreDB`.`Cliente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;
     */
    public class Venda : BaseEntity<int>
    {
        public Venda()
        {
            vendaItems = new List<VendaItem>();
        }


        public Venda(DateTime data, double valt, Usuario usuario, Cliente cli, List<VendaItem> itens)
        {
            vendaItems = new List<VendaItem>();
            Data = data;
            ValorTotal = valt;
            Usuario = usuario;
            Cliente = cli;
            vendaItems = itens;
            
        }

        public DateTime? Data { get; set; }
        public double? ValorTotal { get; set; }
        public Usuario? Usuario { get; set; }
        public Cliente? Cliente { get; set; }
        public List<VendaItem>? vendaItems { get; set; }


        /*CREATE TABLE IF NOT EXISTS `IFSPStoreDB`.`VendaItem` (
      `id` INT NOT NULL AUTO_INCREMENT,
      `Quantidade` INT NULL,
      `ValorUnitario` DECIMAL(10,2) NULL,
      `ValorTotal` DECIMAL(10,2) NULL,
      `idProduto` INT NOT NULL,
      `idVenda` INT NOT NULL,
      PRIMARY KEY (`id`),
      CONSTRAINT `fk_VendaItem_Produto1`
        FOREIGN KEY (`idProduto`)
        REFERENCES `IFSPStoreDB`.`Produto` (`id`)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
      CONSTRAINT `fk_VendaItem_Venda1`
        FOREIGN KEY (`idVenda`)
        REFERENCES `IFSPStoreDB`.`Venda` (`id`)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION)
    ENGINE = InnoDB;*/
        public class VendaItem : BaseEntity<int>
        {
            //public Venda? Venda { get; set; }
            public int? Quantidade { get; set; }
            public double? ValorUnitario { get; set; }
            public double? ValorTotal { get; set; }
            public Produto? Produto { get; set; }


            public VendaItem(int qtd, double vu, double vt, Produto p/*, Venda v*/)
            {
                Quantidade = qtd;
                ValorUnitario = vu;
                ValorTotal = vt;
                Produto = p;
                //Venda = v;
                
            }
            public VendaItem()
            {

            }
        }
    }
}

