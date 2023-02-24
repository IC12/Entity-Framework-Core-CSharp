using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal interface IProdutoDAO
    {
        void Adicionar(Produto p);
        void Atualizar(Produto p);
        void Remover(Produto p);
        IList<Produto> Produtos();
    }
}