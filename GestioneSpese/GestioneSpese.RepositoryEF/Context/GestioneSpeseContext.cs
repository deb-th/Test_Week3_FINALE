using GestioneSpese.EntitiesRepository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese.RepositoryEF.Context
{
    public class GestioneSpeseContext : DbContext
    {
        //Costruttori
        public GestioneSpeseContext() : base() { }
        public GestioneSpeseContext(DbContextOptions<GestioneSpeseContext> options) : base(options) { }

        //Mappo le tabelle
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Spesa> Spese { get; set; }

        //Configurazione della connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False;
                                          Integrated Security = true;
                                          Initial Catalog = GestioneSpese;
                                          Server = .\SQLEXPRESS");
        }

        //Definizione delle relazioni con le Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relazione 1:N
            //una spesa appartiene ad una categotia
            //una categoria incluse più spese
            modelBuilder.Entity<Spesa>()
                        .HasOne(c => c.Categoria)
                        .WithMany(s => s.Spese)
                        .HasForeignKey(x => x.CategoriaId);
        }
    }
}
