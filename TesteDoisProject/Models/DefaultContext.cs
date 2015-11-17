using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TesteDoisProject.Models
{
    public class DefaultContext : DbContext
    {
        public DbSet<Jogador> jogadores { get; set; }
        public DbSet<Selecao> selecoes { get; set; }

        public DbSet<Actor> actores { get; set; }
        public DbSet<Autor> autores { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Copia> copias { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Filme> filmes { get; set; }
        public DbSet<Utente> utentes { get; set; }
        public DbSet<Emprestimo> emprestimos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}