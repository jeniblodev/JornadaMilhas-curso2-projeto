using JornadaMilhasV1.Modelos;
using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Test.Integracao;

public class OfertaViagemDalAdicionar
{
    [Fact]
    public void RegistraOfertaNoBanco()
    { //RegistraOfertaNoBanco[QuandoObjetoNaoEhNulo]
        // Arrange
        Rota rota = new Rota("Origem1", "Destino1");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = 350;

        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            .Options;

        var context = new JornadaMilhasContext(options);

        var oferta = new OfertaViagem(rota, periodo, preco);
        var dal = new OfertaViagemDAL(context); 

        // Act
        dal.Adicionar(oferta);

        // Assert
        
        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.NotNull(ofertaIncluida);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);


        
    }
}