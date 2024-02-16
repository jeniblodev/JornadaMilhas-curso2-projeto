using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace JornadaMilhas.Test.Integracao;
public class ContextoFixture
{
    public ContextoFixture()
    {
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
        .UseSqlServer(_mssqlContainer.GetConnectionString())
        .Options;

         Context = new JornadaMilhasContext(options);
    }

    public JornadaMilhasContext Context { get; }
    private readonly MsSqlContainer _mssqlContainer = new MsSqlBuilder()
    .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
    .Build();
}
