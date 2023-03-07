using Microsoft.EntityFrameworkCore;
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
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoEntrega.Logradouro}");

                var produto = contexto
                    .Produtos
                    //.Include(p => p.Compras)
                    .Where(p => p.Id == 6002)
                    .FirstOrDefault();

                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 10)
                    .Load();

                Console.WriteLine($"\nMostrando as compras do produto {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void ExibeProdutosPromocao()
        {
            using (var contexto2 = new LojaContext())
            {
                var serviceProvider = contexto2.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = contexto2
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();

                Console.WriteLine("\nMostrando os produtos da promoção...");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                //Logar SQL no console
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //Criação da promoção
                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Janeiro";
                promocao.DataInicio = new DateTime(2023, 1, 1);
                promocao.DataTermino = new DateTime(2023, 1, 31);

                //Pega produtos do banco na categoria babidas
                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                //Adicionou na promoção
                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                //Adicionou no contexto
                contexto.Promocoes.Add(promocao);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }
        }

        private static void UmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Válidos",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        public static void MuitosPMuitos()
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            //AtualizarProduto();

            var p1 = new Produto() { Nome = "Barra de Chocolate", Categoria = "Alimentos", PrecoUnitario = 8.79, Unidade = "Gramas" };
            var p2 = new Produto() { Nome = "Refrigerante", Categoria = "Bebidas", PrecoUnitario = 7.45, Unidade = "Litros" };
            var p3 = new Produto() { Nome = "Ovo de Páscoa", Categoria = "Alimentos", PrecoUnitario = 34.99, Unidade = "Gramas" };

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

                //var entry = contexto.Entry(novoProd);
                //Console.WriteLine("\n\n" + entry.Entity.ToString() + " - " + entry.State);
                //ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("================");
            foreach (var item in entries)
            {
                //usando State se a variável foi modificada ou não
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
