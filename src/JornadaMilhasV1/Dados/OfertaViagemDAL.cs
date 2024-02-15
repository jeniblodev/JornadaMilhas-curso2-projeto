using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Dados;
public class OfertaViagemDAL
{
    private readonly JornadaMilhasContext context;

    public OfertaViagemDAL(JornadaMilhasContext context)
    {
        this.context = context;
    }

    public void Adicionar(OfertaViagem oferta)
    {
        context.OfertasViagem.Add(oferta);
        context.SaveChanges();
    }

    public OfertaViagem RecuperarPorId(int id)
    {
        return context.OfertasViagem.FirstOrDefault(o => o.Id == id);
    }

    public IEnumerable<OfertaViagem> RecuperarTodas()
    {
        return context.OfertasViagem.ToList();
    }

    public void Atualizar(OfertaViagem oferta)
    {
        context.OfertasViagem.Update(oferta);
        context.SaveChanges();
    }

    public void Remover(OfertaViagem oferta)
    {
        context.OfertasViagem.Remove(oferta);
        context.SaveChanges();
    }

    public OfertaViagem RecuperaMaiorDesconto(Func<OfertaViagem, bool> filtro)
    {
        return context.OfertasViagem
            .Where(filtro)
            .Where(o => o.Ativa)
            .OrderBy(o => o.Preco)
            .FirstOrDefault();
    }
}
