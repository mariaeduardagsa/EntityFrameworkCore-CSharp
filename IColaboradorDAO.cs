using System.Collections.Generic;

namespace CRUD___Simples
{
    interface IColaboradorDAO
    {
        void Adicionar(Colaborador c);
        void Atualizar(Colaborador c);
        void Remover(Colaborador c);
        IList<Colaborador> Colaborador();
    }
}
