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
            //var paoFrances = new Produto();
            //paoFrances.Nome = "Pão Francês";
            //paoFrances.PrecoUnitario = 0.40;
            //paoFrances.Unidade = "Unidade";
            //paoFrances.Categoria = "Panificadora";

            //var compra = new Compra();
            //compra.Quantidade = 6;
            //compra.Produto = paoFrances;
            //compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            var p1 = new Produto() {Nome = "Barra de Chocolate", Categoria = "Alimentos", PrecoUnitario = 8.79, Unidade = "Gramas"};
            var p2 = new Produto() {Nome = "Refrigerante", Categoria = "Bebidas", PrecoUnitario = 7.45, Unidade = "Litros"};
            var p3 = new Produto() {Nome = "Ovo de Páscoa", Categoria = "Alimentos", PrecoUnitario = 34.99, Unidade = "Gramas"};

            var promocaoPascoa = new Promocao();
            promocaoPascoa.Descricao = "Páscoa Feliz";
            promocaoPascoa.DataInicio = DateTime.Now;
            promocaoPascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoPascoa.IncluiProduto(p1);
            promocaoPascoa.IncluiProduto(p2);
            promocaoPascoa.IncluiProduto(p3);

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //contexto.Promocoes.Add(promocaoPascoa);
                var promocao = contexto.Promocoes.Find(1);
                contexto.Promocoes.Remove(promocao);
                //ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

                //contexto.Compras.Add(compra);

                //ExibeEntries(contexto.ChangeTracker.Entries());

                //contexto.SaveChanges();
            }

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

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("================");
            foreach (var item in entries)
            {
                Console.WriteLine(item.Entity.ToString() + " - " + item.State);
            }
        }

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
