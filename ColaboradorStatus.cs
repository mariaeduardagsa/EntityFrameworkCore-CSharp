using Microsoft.EntityFrameworkCore;
using System;

namespace CRUD___Simples
{
    public class ColaboradorStatus : DbContext
    {
        public DbSet<Colaborador> Colaborador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CRUD;Trusted_Connection=true;");
        }

     
    }
}