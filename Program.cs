using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD___Simples
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static void MudarAtivo()
        {
            using (var contexto = new ColaboradorStatus())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                Colaborador exemplo = contexto.Colaborador.First();
                exemplo.Ativo = true;
                contexto.Update(exemplo);

                Console.WriteLine(exemplo.ToString());

            }
        }

        private static void BuscarPorAtivo()
        {
            using (var contexto = new ColaboradorStatus())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var colaborador = contexto
                    .Colaborador
                    .Where(c => c.Ativo == true)
                    .ToList();

                Console.WriteLine(colaborador);
                foreach (var item in colaborador)
                {
                    Console.WriteLine("\t" + item);
                }

            }
        }

        private static void BuscarPorId()
        {
            using (var contexto = new ColaboradorStatus())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var colaborador = contexto
                    .Colaborador
                    .Where(c => c.Id == 1002)
                    .FirstOrDefault()
                    .ToString();

                Console.WriteLine(colaborador);


            }
        }

        private static void ExcluirUltimoColaborador()
        {
            using (var contexto = new ColaboradorStatus())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var colaborador = contexto.Colaborador.ToList();

                ExibeEntries(contexto.ChangeTracker.Entries());

                var novoColaborador = new Colaborador()
                {
                    Nome = "Silvia Mendonça",
                    Sexo = "Feminino",
                    DataDeNascimento = new DateTime(1991, 01, 17),
                    Cargo = "Administrativo",
                    Ativo = true
                };

                var colaboradorUltimo = contexto.Colaborador.Last();
                contexto.Colaborador.Remove(colaboradorUltimo);


                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

                ExibeEntries(contexto.ChangeTracker.Entries());
            }
        }

        private static void IncluirColaborador()
        {
            using (var contexto = new ColaboradorStatus())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var colaborador = contexto.Colaborador.ToList();

                ExibeEntries(contexto.ChangeTracker.Entries());

                var novoColaborador = new Colaborador()
                {
                    Nome = "Silvia Mendonça",
                    Sexo = "Feminino",
                    DataDeNascimento = new DateTime(1991, 01, 17),
                    Cargo = "Administrativo",
                    Ativo = true
                };

                contexto.Colaborador.Add(novoColaborador);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

                ExibeEntries(contexto.ChangeTracker.Entries());
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("=============================");
            foreach (var e in entries)
            {

                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
    }
}
