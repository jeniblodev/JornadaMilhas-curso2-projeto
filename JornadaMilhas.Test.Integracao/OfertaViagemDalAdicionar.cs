using JornadaMilhasV1.Modelos;
using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using Bogus;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalAdicionar
{
    private readonly OfertaViagemDAL dal;
    private readonly ITestOutputHelper output;


    public OfertaViagemDalAdicionar(ITestOutputHelper output, ContextoFixture fixture)
    {
        dal = new OfertaViagemDAL(fixture.Context);
        this.output = output;

        output.WriteLine(fixture.Context.GetHashCode().ToString());

        InserirDadosNoBanco();
    }

    private void InserirDadosNoBanco()
    {
        var faker = new Faker();
        var rota = new Rota(faker.Address.City(), faker.Address.City());
        var periodo = new Periodo(faker.Date.Between(new DateTime(2022, 1, 1), new DateTime(2025, 12, 31)),
                                  faker.Date.Between(new DateTime(2025, 1, 1), new DateTime(2026, 12, 31)));
        var preco = faker.Random.Double(100, 1000);

        dal.Adicionar(new OfertaViagem(rota, periodo, preco));
    }

    [Fact]
    public void RegistraOfertaNoBanco()
    { 
        // Arrange
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