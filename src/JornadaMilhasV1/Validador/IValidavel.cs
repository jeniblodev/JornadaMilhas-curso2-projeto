using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV1.Validador;

public class Erros : IEnumerable<Erro>
{
    private readonly ICollection<Erro> erros = new List<Erro>();

    public void RegistrarErro(string mensagem) => erros.Add(new Erro(mensagem));

    public IEnumerator<Erro> GetEnumerator()
    {
        return erros.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return erros.GetEnumerator();
    }

    public string Sumario
    {
        get
        {
            var sb = new StringBuilder();
            foreach (var item in erros)
                sb.AppendLine(item.Mensagem);
            return sb.ToString();
        }
    }
}

public record Erro(string Mensagem);

internal interface IValidavel
{
    // bool Validar();
    bool EhValido { get; }
    Erros Erros { get; }
}
