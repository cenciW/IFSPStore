using IFSPStore.Domain.Entities;
using IFSPSTore.Domain.Entities;

namespace IFSPStore.Teste
{
    public class Class1
    {
        Cidade cida = new Cidade("Araçatuba", "SP");
        cida.Estado;
        Usuario user = new Usuario("José Cenci", "SENHA#HARD", "ZECNC", "ZECNC@GMAIL.com", DateTime.UtcNow.ToLocalTime(), DateTime.UtcNow.ToLocalTime(), true, cida);
        Cliente cli = new Cliente("Cliente jeferson", "Jeff Landia", "530000", "Portal da Pérola II", cida);
    
    }
}