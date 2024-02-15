using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.Integracao;
public class ContextoFixture
{
    public ContextoFixture()
    {
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
        .Options;

         Context = new JornadaMilhasContext(options);
    }

    public JornadaMilhasContext Context { get; }
}
