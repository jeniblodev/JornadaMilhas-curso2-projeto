using JornadaMilhasV1.Modelos;
using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

public class OfertaViagemDalAdicionar: IClassFixture<ContextoFixture>
{
    private readonly OfertaViagemDAL dal;
    private readonly ITestOutputHelper output;

    public OfertaViagemDalAdicionar(ITestOutputHelper output, ContextoFixture fixture)
    {
/*        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
        .Options;

        var context = new JornadaMilhasContext(options);*/
        dal = new OfertaViagemDAL(fixture.Context);
        this.output = output;

        /*output.WriteLine(context.Timestamp.ToString());*/

        output.WriteLine(fixture.Context.Timestamp.ToString());
    }

    [Fact]
    public void RegistraOfertaNoBanco()
    { //RegistraOfertaNoBanco[QuandoObjetoNaoEhNulo]
        // Arrange
        Rota rota = new Rota("Origem1", "Destino1");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = 350;

        var oferta = new OfertaViagem(rota, periodo, preco);

        // Act
        dal.Adicionar(oferta);

        // Assert
        
        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.NotNull(ofertaIncluida);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);
        
    }

    [Fact]
    public void RegistraOfertaNoBancoComInformacoesCorretas()
    { 
        // Arrange
        Rota rota = new Rota("Origem1", "Destino1");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = 350;

        var oferta = new OfertaViagem(rota, periodo, preco);

        // Act
        dal.Adicionar(oferta);

        // Assert
        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.Equal(ofertaIncluida.Rota.Origem, oferta.Rota.Origem);
        Assert.Equal(ofertaIncluida.Rota.Destino, oferta.Rota.Destino);
        Assert.Equal(ofertaIncluida.Periodo.DataInicial, oferta.Periodo.DataInicial);
        Assert.Equal(ofertaIncluida.Periodo.DataFinal, oferta.Periodo.DataFinal);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);

    }
}