using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperarPorId
{
    private readonly OfertaViagemDAL dal;
    private readonly ITestOutputHelper output;

    public OfertaViagemDalRecuperarPorId(ITestOutputHelper output, ContextoFixture fixture)
    {
        dal = new OfertaViagemDAL(fixture.Context);
        this.output = output;


        output.WriteLine(fixture.Context.GetHashCode().ToString());
    }

    [Fact]
    public void RetornaNuloQuandoIdInexistente()
    { 
        // Arrange
        // Act
        var ofertaRecuperada = dal.RecuperarPorId(-2);

        // Assert

        Assert.Null(ofertaRecuperada);
       

    }
}
