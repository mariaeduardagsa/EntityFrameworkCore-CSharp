using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD___Simples
{
    public class ColaboradorDAOEntity : IColaboradorDAO, IDisposable
    {
        private ColaboradorStatus contexto;

        public void Adicionar(Colaborador c)
        {
            contexto.Colaborador.Add(c);
            contexto.SaveChanges();
        }

        public void Atualizar(Colaborador c)
        {
            contexto.Colaborador.Update(c);
            contexto.SaveChanges();
        }

        public IList<Colaborador> Colaborador()
        {
            return contexto.Colaborador.ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Remover(Colaborador c)
        {
            contexto.Colaborador.Remove(c);
            contexto.SaveChanges();
        }
    }
}
