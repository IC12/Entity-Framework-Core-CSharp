using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            //AtualizarProduto();

            //using (var contexto = new LojaContext())
            //{
            //    var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
            //    var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            //    loggerFactory.AddProvider(SqlLoggerProvider.Create());

            //    var produtos = contexto.Produtos.ToList();

            //    ExibeEntries(contexto.ChangeTracker.Entries());

            //    //var p1 = produtos.Last();
            //    //p1.Nome = "007 - Cassino Royale";
            //    //contexto.SaveChanges();

            //    var novoProd = new Produto()
            //    {
            //        Nome = "Sabão em pó",
            //        Categoria = "Limpeza",
            //        Preco = 4.99
            //    };
            //    contexto.Produtos.Add(novoProd);

            //    //usando State se a variável foi modificada ou não
            //    ExibeEntries(contexto.ChangeTracker.Entries());

            //    contexto.Produtos.Remove(novoProd);

            //    ExibeEntries(contexto.ChangeTracker.Entries());

            //    //contexto.SaveChanges();

            //    var entry = contexto.Entry(novoProd);
            //    Console.WriteLine("\n\n" + entry.Entity.ToString() + " - " + entry.State);
            //}
        }

        //private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        //{
        //    Console.WriteLine("================");
        //    foreach (var item in entries)
        //    {
        //        Console.WriteLine(item.Entity.ToString() + " - " + item.State);
        //    }
        //}

        //private static void AtualizarProduto()
        //{
        //    //incluir um produto
        //    GravarUsandoEntity();
        //    RecuperarProdutos();

        //    //atualizar o produto
        //    using (var repo = new ProdutoDAOEntity())
        //    {
        //        Produto primeiro = repo.Produtos().First();
        //        primeiro.Nome = "Cassino Royale - Editado";
        //        repo.Atualizar(primeiro);
        //    }
        //    RecuperarProdutos();
        //    Console.Read();
        //}

        //private static void ExcluirProdutos()
        //{
        //    using (var repo = new ProdutoDAOEntity())
        //    {
        //        IList<Produto> produtos = repo.Produtos();
        //        Console.WriteLine("Foram excluídos {0} produto(s).", produtos.Count);
        //        foreach (var item in produtos)
        //        {
        //            repo.Remover(item);
        //        }
        //    }
        //}

        //private static void RecuperarProdutos()
        //{
        //    using (var repo = new ProdutoDAOEntity())
        //    {
        //        IList<Produto> produtos = repo.Produtos();
        //        Console.WriteLine("Foram encontrados {0} produto(s).", produtos.Count);
        //        foreach (var item in produtos)
        //        {
        //            Console.WriteLine(item.Nome);
        //        }
        //    }
        //}

        //private static void GravarUsandoEntity()
        //{
        //    Produto p = new Produto();
        //    p.Nome = "Harry Potter e a Ordem da Fênix";
        //    p.Categoria = "Livros";
        //    p.Preco = 19.89;

        //    using (var repo = new ProdutoDAOEntity())
        //    {
        //        repo.Adicionar(p);
        //    }
        //}

        //private static void GravarUsandoAdoNet()
        //{
        //    Produto p = new Produto();
        //    p.Nome = "Harry Potter e a Ordem da Fênix";
        //    p.Categoria = "Livros";
        //    p.Preco = 19.89;

        //    using (var repo = new ProdutoDAO())
        //    {
        //        repo.Adicionar(p);
        //    }
        //}
    }
}
